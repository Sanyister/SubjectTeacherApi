using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using zsoow6TeacherSubjApi.Model.Entity;
using zsoow6TeacherSubjApi.UnitOfWork;

namespace zsoow6TeacherSubjApi.Services
{
    public class CacheService: ICacheService
    {
        private readonly IMemoryCache _cache; 
        private readonly IUnitOfWork _unitOfWork;

        public CacheService(IMemoryCache cache, IUnitOfWork unitOfWork)
        {
            _cache = cache;
            _unitOfWork = unitOfWork;
        }

        public void SetCache()
        {
            //thenInclude
           /* _unitOfWork.GetDbSet<Subject>().AsNoTracking().Include(r => r.semesterTeacher).Include(r => r.semesterStudent).Include(r => r.semesterTimetable).ToList().ForEach(subject =>
            {
                _cache.Set(subject.Code, subject);
                _cache.Set(subject.Id, subject);
            });*/
        }

        public bool TryGetValue<TEntity>(object cacheKey, out TEntity value)
        {
            return _cache.TryGetValue<TEntity>(cacheKey, out value);
        }

        public void Remove(object cacheKey)
        {
            _cache.Remove(cacheKey);
        }

        public void Set(object cacheKey, object value)
        {
            _cache.Set(cacheKey, value);
        }
    }
}
