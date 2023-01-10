using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using zsoow6TeacherSubjApi.Model.Entity;
using System.Xml;

namespace zsoow6TeacherSubjApi.Model.Entity
{
    public class Subject : AbstractEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Credit { get; set; }
        public string Professorate { get; set; }


        public virtual ICollection<SemesterTeacher> semesterTeacher { get; set; }
        public virtual ICollection<SemesterStudent> semesterStudent { get; set; }

        public virtual ICollection<SubjectTimetable> semesterTimetable { get; set; }
    }
    public class SubjectEntityTypeConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasQueryFilter(e => !e.Deleted);

        }
    }
}
