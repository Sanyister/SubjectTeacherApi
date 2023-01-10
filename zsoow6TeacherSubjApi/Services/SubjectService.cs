using zsoow6TeacherSubjApi.UnitOfWork;
using zsoow6TeacherSubjApi.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using zsoow6TeacherSubjApi.Model.DTO;
using zsoow6TeacherSubjApi.Services;

namespace zsoow6TeacherSubjApi.Services
{
    public class SubjectService: ISubjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cacheService;
        public SubjectService(IUnitOfWork unitOfWork, ICacheService cacheService)
        {
            _unitOfWork = unitOfWork;
            _cacheService = cacheService;
        }
        public IQueryable<Subject> GetAll(bool containDeleted)
        {
            return GetBasedOnContainDeleted(containDeleted);
        }
        private IQueryable<Subject> GetBasedOnContainDeleted(bool containDeleted)
        {
            return containDeleted ? _unitOfWork.GetRepository<Subject>().GetAll().IgnoreQueryFilters() : _unitOfWork.GetRepository<Subject>().GetAll();
            //return containDeleted ? _trainCarAPIDbContext.Set<RollingStock>().IgnoreQueryFilters() : _trainCarAPIDbContext.Set<RollingStock>();
        }
        public IQueryable<Subject> GetAllBySemesterAndTeacher(int teacherId, int semesterId)
        {
            return _unitOfWork.GetRepository<Subject>().GetAll().IgnoreQueryFilters().Where(s => 
               s.semesterTeacher.ToList().Where(st => st.Teacher.Id == teacherId && st.Semester.Id == semesterId).ToList().Count() > 0
            );
        }

        public IQueryable<Subject> GetAllBySemesterAndStudent(int studentId, int semesterId)
        {
            return _unitOfWork.GetRepository<Subject>().GetAll().IgnoreQueryFilters().Where(s =>
               s.semesterStudent.ToList().Where(st => st.Student.Id == studentId && st.Semester.Id == semesterId).ToList().Count() > 0
            );
        }

          public async Task DeleteSubject(int id)
        {
            var subjectToDelete = await _unitOfWork.GetRepository<Subject>().GetById(id);

            subjectToDelete.Deleted = true;
            _unitOfWork.GetRepository<Subject>().Update(subjectToDelete);
            await _unitOfWork.SaveChangesAsync();

        }

        public async Task UpdateSubject(Subject subject)
        {
            var subjectToUpdate = await _unitOfWork.GetRepository<Subject>().GetById(subject.Id);
            subjectToUpdate.Professorate = subject.Professorate;
            subjectToUpdate.semesterTeacher = subject.semesterTeacher;
            subjectToUpdate.semesterStudent = subject.semesterStudent;
            subjectToUpdate.Code = subject.Code;
            subjectToUpdate.Credit = subject.Credit;
            subjectToUpdate.Name = subject.Name;
            subjectToUpdate.semesterTimetable = subject.semesterTimetable;
            _unitOfWork.GetRepository<Subject>().Update(subjectToUpdate);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Subject> AddSubject(Subject subject)
        {
            Subject savedSubject = await _unitOfWork.GetRepository<Subject>().Create(subject);
            await _unitOfWork.SaveChangesAsync();

            return savedSubject;
        }

        public List<StudentDTO> GetAllStudentBySemesterAndTeacher(int teacherId, int semesterId) {
            List<StudentDTO> result = new List<StudentDTO>();
            List<Subject> subjects = _unitOfWork.GetRepository<Subject>().GetAll().Where(s =>
               s.semesterTeacher.ToList().Where(st => st.Teacher.Id == teacherId && st.Semester.Id == semesterId).ToList().Count() > 0
            ).ToList();
            subjects.ForEach(s =>
            {
                s.semesterStudent.Where(se => se.Semester.Id == semesterId).ToList().ForEach(ss => {
                    StudentDTO studentDto = new StudentDTO();
                    studentDto.Name = ss.Student.Name;
                    studentDto.NeptunCode = ss.Student.NeptunCode;
                    studentDto.SubjectName = s.Name;
                    result.Add(studentDto);
                });
            });

            return result.OrderBy(s => s.SubjectName).ThenBy(s => s.Name).ToList();
        }
        public AggregatedSubjectDTO GetAggergatedSubjectBySemesterAndTeacher(int teacherId, int semesterId)
        {
            AggregatedSubjectDTO result = new AggregatedSubjectDTO();
            List<Student> students = new List<Student>();
            int sumSubjectCredit = 0;
            int studentCount = 0;
            List<Subject> subjects = _unitOfWork.GetRepository<Subject>().GetAll().Where(s =>
            s.semesterTeacher.ToList().Where(st => st.Teacher.Id == teacherId && st.Semester.Id == semesterId).ToList().Count() > 0
         ).ToList();
            subjects.ForEach(s =>
            {
                s.semesterStudent.Where(se => se.Semester.Id == semesterId).ToList().ForEach(ss => {
                    if (!students.Contains(ss.Student)) { 
                        students.Add(ss.Student);
                        studentCount++; 
                    }
                });
                sumSubjectCredit += s.Credit;
            });
            result.StudentCount = studentCount;
            result.CreditCount = sumSubjectCredit;
            return result;
        }

        public Subject GetById(int id)
        {
            return _unitOfWork.Context().Set<Subject>().IgnoreQueryFilters().Where(r => r.Id == id).FirstOrDefault();
        }



        public IEnumerable<Subject> GetAboveCredit()
        {
            return _unitOfWork.GetRepository<Subject>().GetAll().ToList()
             .Where(rs => rs.Credit>=4);
        }

    }
}
