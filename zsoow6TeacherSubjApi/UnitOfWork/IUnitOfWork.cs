using Microsoft.EntityFrameworkCore;
using zsoow6TeacherSubjApi.Model.Entity;
using zsoow6TeacherSubjApi.Repository;

namespace zsoow6TeacherSubjApi.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : AbstractEntity;
        DbSet<TEntity> GetDbSet<TEntity>() where TEntity : AbstractEntity;
        int SaveChanges();
        Task SaveChangesAsync();
        DbContext Context();
    }
}
