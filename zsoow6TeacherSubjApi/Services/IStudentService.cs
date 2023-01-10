using zsoow6TeacherSubjApi.Model.Entity;

namespace zsoow6TeacherSubjApi.Services
{
    public interface IStudentService
    {
        public IQueryable<Student> GetAll(bool containDeleted);
        public Task<Student> AddStudent(Student student);

        public Task UpdateStudent(Student student);

        public Task DeleteStudent(int id);

    }
}
