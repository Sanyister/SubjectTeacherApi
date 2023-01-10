using zsoow6TeacherSubjApi.Model.Entity;

namespace zsoow6TeacherSubjApi.Services
{
    public interface ISemesterService
    {
        public IQueryable<Semester> GetAll(bool containDeleted);
        public Task<Semester> AddSemester(Semester semester);

        public Task UpdateSemester(Semester semester);

        public Task DeleteSemester(int id);

    }
}
