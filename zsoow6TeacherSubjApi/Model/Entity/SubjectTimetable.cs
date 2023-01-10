using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace zsoow6TeacherSubjApi.Model.Entity
{
    public class SubjectTimetable : AbstractEntity
    {
        public Semester semester { get; set; }

        public string timetable { get; set; } = "ismeretlen";
    }
    public class SubjectTimetableEntityTypeConfiguration : IEntityTypeConfiguration<SubjectTimetable>
    {
        public void Configure(EntityTypeBuilder<SubjectTimetable> builder)
        {
            builder.HasQueryFilter(e => !e.Deleted);

        }
    }
}
