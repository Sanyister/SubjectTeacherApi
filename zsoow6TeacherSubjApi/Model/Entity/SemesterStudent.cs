using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace zsoow6TeacherSubjApi.Model.Entity
{

    public class SemesterStudent:AbstractEntity
    {
        public int Id { get; set; }
        public Semester Semester { get; set; }

        public Student Student { get; set; }
    }
    public class SemesterStudentEntityTypeConfiguration : IEntityTypeConfiguration<SemesterStudent>
    {
        public void Configure(EntityTypeBuilder<SemesterStudent> builder)
        {
            builder.HasQueryFilter(e => !e.Deleted);

        }
    }
}
