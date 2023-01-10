using Microsoft.EntityFrameworkCore;
using zsoow6TeacherSubjApi.Context;
using zsoow6TeacherSubjApi.Model.Entity;

namespace zsoow6TeacherSubjApi.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : AbstractEntity
    {

        private readonly Zsoow6TeacherSubjApiContext _zsoow6TeacherSubjApiContext;
        protected readonly DbSet<TEntity> DbSet;
        public GenericRepository(Zsoow6TeacherSubjApiContext zsoow6TeacherSubjApiContext)
        {
            _zsoow6TeacherSubjApiContext = zsoow6TeacherSubjApiContext;
            DbSet = _zsoow6TeacherSubjApiContext.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public async Task<TEntity> GetById(int id)
        {
            return await DbSet.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            var createdEntity = await DbSet.AddAsync(entity);
            return createdEntity.Entity;
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            DbSet.Remove(entity);
        }
         
        public async Task<TEntity> DeleteSoft(int id)
        {
            var entity = await GetById(id);
            entity.Deleted = true;
            Update(entity);
            return entity;
        }
    }
}
