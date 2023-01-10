using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace zsoow6TeacherSubjApi.Model.Entity
{
    public class SemesterTeacher:AbstractEntity
    {
        public int Id { get; set; }
        public Semester Semester { get; set; }

        public Teacher Teacher { get; set; }
    }
    public class SemesterTeacherEntityTypeConfiguration : IEntityTypeConfiguration<SemesterTeacher>
    {
        public void Configure(EntityTypeBuilder<SemesterTeacher> builder)
        {
            builder.HasQueryFilter(e => !e.Deleted);

        }
    }
}
