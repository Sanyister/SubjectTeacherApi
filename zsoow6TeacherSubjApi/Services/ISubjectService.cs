using Microsoft.VisualBasic;
using zsoow6TeacherSubjApi.Model.DTO;
using zsoow6TeacherSubjApi.Model.Entity;

namespace zsoow6TeacherSubjApi.Services
{
    public interface ISubjectService
    {
        public IQueryable<Subject> GetAll(bool containDeleted);
        public IQueryable<Subject> GetAllBySemesterAndTeacher(int teacherId,int semesterId);

        public IQueryable<Subject> GetAllBySemesterAndStudent(int studentId, int semesterId);
        public  Task<Subject> AddSubject(Subject subject);

        public  Task UpdateSubject(Subject subject);

        public  Task DeleteSubject(int id);

        public List<StudentDTO> GetAllStudentBySemesterAndTeacher(int teacherId, int semesterId);

        public AggregatedSubjectDTO GetAggergatedSubjectBySemesterAndTeacher(int teacherId, int semesterId);

        public Subject GetById(int id);


        public IEnumerable<Subject> GetAboveCredit();
    }
}
