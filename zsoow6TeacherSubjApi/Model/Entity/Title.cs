using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using zsoow6TeacherSubjApi.Model.Entity;

namespace zsoow6TeacherSubjApi.Model.Entity
{
    public enum TitleName
    {
        docens,
        adjunktus,
        mesteroktató,
        ügyvivő_szakértő,
        tanársegéd,
        egyéb
    }
    public class Title : AbstractEntity
    {
        public TitleName title { get; set; }

    }
    public class TitleEntityTypeConfiguration : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> builder)
        {
            builder.HasQueryFilter(e => !e.Deleted);

        }
    }
}
