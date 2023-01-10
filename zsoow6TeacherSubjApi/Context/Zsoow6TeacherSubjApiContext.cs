
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using zsoow6TeacherSubjApi.Model.Entity;

namespace zsoow6TeacherSubjApi.Context
{
    public class Zsoow6TeacherSubjApiContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {

        public Zsoow6TeacherSubjApiContext(DbContextOptions<Zsoow6TeacherSubjApiContext> options) : base(options)
        {
            Database.SetCommandTimeout(60);
        }
        //optionsbuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ZSOOW6");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.RemovePluralizingTableNameConvention();
            modelBuilder.RemoveOneToManyCascadeDeleteConvention();

            base.OnModelCreating(modelBuilder);
        }
    }

    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Define the name of the table to be the name of the entity
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void RemovePluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                if (entity.BaseType == null && !HasAttribute(entity.ClrType, typeof(TableAttribute)))
                {
                    entity.SetTableName(entity.DisplayName());
                }
            }
        }
       

        /// <summary>
        /// Disable cascade deletion for one or more connections
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void RemoveOneToManyCascadeDeleteConvention(this ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
        }

        private static bool HasAttribute(Type type, Type attributeType)
        {
            return type.GetCustomAttribute(attributeType) != null;
        }
    }


}
