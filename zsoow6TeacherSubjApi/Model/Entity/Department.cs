using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using zsoow6TeacherSubjApi.Model.Entity;

namespace zsoow6TeacherSubjApi.Model.Entity
{
    public enum Speciality
    {
        Mérnökinformatikus_Msc,
        Programtervező_informatikus_Msc,
        Mérnökinformatikus_Bsc,
        Programtervező_informatikus_Bsc,
        Gazdaságinformatikus_Bsc
    }
    public class Department : AbstractEntity
    {
        public Speciality speciality { get; set; }
    }
    public class DepartmentEntityTypeConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasQueryFilter(e => !e.Deleted);

        }
    }
}
