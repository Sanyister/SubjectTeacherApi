using Microsoft.EntityFrameworkCore;
using zsoow6TeacherSubjApi.Context;
using zsoow6TeacherSubjApi.Model.Entity;
using zsoow6TeacherSubjApi.Repository;

namespace zsoow6TeacherSubjApi.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Zsoow6TeacherSubjApiContext _zsoow6TeacherSubjApiContext;
        private Dictionary<Type, object> _repositories;


        public UnitOfWork(Zsoow6TeacherSubjApiContext zsoow6TeacherSubjApiContext)
        {
            _zsoow6TeacherSubjApiContext = zsoow6TeacherSubjApiContext;
        }

        public DbContext Context()
        {
            return _zsoow6TeacherSubjApiContext;
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : AbstractEntity
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type))
            {
                _repositories[type] = new GenericRepository<TEntity>(_zsoow6TeacherSubjApiContext);
            }

            return (IGenericRepository<TEntity>)_repositories[type];

        }

        public int SaveChanges()
        {
            return _zsoow6TeacherSubjApiContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _zsoow6TeacherSubjApiContext.Dispose();
            }
        }

        public DbSet<TEntity> GetDbSet<TEntity>() where TEntity : AbstractEntity
        {
            return _zsoow6TeacherSubjApiContext.Set<TEntity>();
        }

        public Task SaveChangesAsync()
        {
            return _zsoow6TeacherSubjApiContext.SaveChangesAsync();
        }
    }
}
