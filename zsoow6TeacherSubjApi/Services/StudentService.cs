using zsoow6TeacherSubjApi.UnitOfWork;
using zsoow6TeacherSubjApi.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace zsoow6TeacherSubjApi.Services
{
    public class StudentService: IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IQueryable<Student> GetAll(bool containDeleted)
        {
            return GetBasedOnContainDeleted(containDeleted);
        }
        private IQueryable<Student> GetBasedOnContainDeleted(bool containDeleted)
        {
            return containDeleted ? _unitOfWork.GetRepository<Student>().GetAll().IgnoreQueryFilters() : _unitOfWork.GetRepository<Student>().GetAll();
        }
        public async Task DeleteStudent(int id)
        {
            var studentToDelete = await _unitOfWork.GetRepository<Student>().GetById(id);

            studentToDelete.Deleted = true;
            _unitOfWork.GetRepository<Student>().Update(studentToDelete);
            await _unitOfWork.SaveChangesAsync();

        }
        public async Task UpdateStudent(Student student)
        {
            var semesterToUpdate = await _unitOfWork.GetRepository<Student>().GetById(student.Id);
            semesterToUpdate.NeptunCode = student.NeptunCode;
            semesterToUpdate.Name = student.Name;
            semesterToUpdate.Email = student.Email;
            semesterToUpdate.Department = student.Department; 
            semesterToUpdate.Subjects = student.Subjects; 
            _unitOfWork.GetRepository<Student>().Update(semesterToUpdate);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<Student> AddStudent(Student student) { 

            Student savedStudent = await _unitOfWork.GetRepository<Student>().Create(student);
            await _unitOfWork.SaveChangesAsync();

            return savedStudent;
        }
    }
}
