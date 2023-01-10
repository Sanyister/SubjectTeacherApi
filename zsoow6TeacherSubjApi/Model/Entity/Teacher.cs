using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using zsoow6TeacherSubjApi.Model.Entity;

namespace zsoow6TeacherSubjApi.Model.Entity
{
    public class Teacher: AbstractEntity
    {
        public string NeptunCode { get; set; }
        public string Name { get; set; }

        public virtual Title title { get; set; }

    }
    public class TeacherEntityTypeConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasQueryFilter(e => !e.Deleted);

        }
    }
}
