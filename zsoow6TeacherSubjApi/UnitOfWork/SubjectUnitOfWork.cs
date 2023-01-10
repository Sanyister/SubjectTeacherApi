using Microsoft.EntityFrameworkCore;
using zsoow6TeacherSubjApi.Context;
using zsoow6TeacherSubjApi.Model.Entity;
using zsoow6TeacherSubjApi.UnitOfWork;

namespace zsoow6TeacherSubjApi.UnitOfWork
{
    public class SubjectUnitOfWork : UnitOfWork, ISubjectUnitOfWork
    {

        public SubjectUnitOfWork(Zsoow6TeacherSubjApiContext zsoow6TeacherSubjApiContext) : base(zsoow6TeacherSubjApiContext)
        {
        }

        public IQueryable<Subject> GetSubjectBySemesterInterval(DateTime start, DateTime end)
        {
            return GetRepository<Subject>().GetAll()
                .Where(s => s.semesterTimetable
                            .Where(st => !st.timetable.Equals("ismeretlen")).ToList()
                            .Where(st => WithInRange(st.semester.StartDate, start, end) || WithInRange(st.semester.EndDate, start, end))
                            .ToList().Count > 0
                );
        }
        public bool WithInRange(DateTime value, DateTime start, DateTime end)
        {
            return (start <= value) && (value <= end);
        }

    }
}
