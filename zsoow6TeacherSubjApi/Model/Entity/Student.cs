using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using zsoow6TeacherSubjApi.Model.Entity;

namespace zsoow6TeacherSubjApi.Model.Entity
{
    public class Student : AbstractEntity
    {

        public string NeptunCode { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
    public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasQueryFilter(e => !e.Deleted);

        }
    }
}
