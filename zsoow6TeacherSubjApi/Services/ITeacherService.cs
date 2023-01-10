using zsoow6TeacherSubjApi.Model.Entity;

namespace zsoow6TeacherSubjApi.Services
{
    public interface ITeacherService
    {
        public IQueryable<Teacher> GetAll(bool containDeleted);
        public Task<Teacher> AddTeacher(Teacher teacher);

        public Task UpdateTeacher(Teacher teacher);

        public Task DeleteTeacher(int id);

    }
}
