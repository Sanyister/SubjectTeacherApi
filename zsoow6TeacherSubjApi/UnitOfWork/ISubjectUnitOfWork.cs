using zsoow6TeacherSubjApi.Model.Entity;

namespace zsoow6TeacherSubjApi.UnitOfWork
{
    public interface ISubjectUnitOfWork
    {
        public IQueryable<Subject> GetSubjectBySemesterInterval(DateTime start, DateTime end);
    }
}
