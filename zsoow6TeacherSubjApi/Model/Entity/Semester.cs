using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using zsoow6TeacherSubjApi.Model.Entity;

namespace zsoow6TeacherSubjApi.Model.Entity
{
    public class Semester : AbstractEntity
    {

        public string Name { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
    public class SemesterEntityTypeConfiguration : IEntityTypeConfiguration<Semester>
    {
        public void Configure(EntityTypeBuilder<Semester> builder)
        {
            builder.HasQueryFilter(e => !e.Deleted);
        }
    }
}
