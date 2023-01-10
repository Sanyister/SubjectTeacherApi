using zsoow6TeacherSubjApi.UnitOfWork;
using zsoow6TeacherSubjApi.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace zsoow6TeacherSubjApi.Services
{
    public class TeacherService: ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TeacherService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IQueryable<Teacher> GetAll(bool containDeleted)
        {
            return GetBasedOnContainDeleted(containDeleted);
        }
        private IQueryable<Teacher> GetBasedOnContainDeleted(bool containDeleted)
        {
            return containDeleted ? _unitOfWork.GetRepository<Teacher>().GetAll().IgnoreQueryFilters() : _unitOfWork.GetRepository<Teacher>().GetAll();
            //return containDeleted ? _trainCarAPIDbContext.Set<RollingStock>().IgnoreQueryFilters() : _trainCarAPIDbContext.Set<RollingStock>();
        }
        public async Task DeleteTeacher(int id)
        {
            var teacherToDelete = await _unitOfWork.GetRepository<Teacher>().GetById(id);

            teacherToDelete.Deleted = true;
            _unitOfWork.GetRepository<Teacher>().Update(teacherToDelete);
            await _unitOfWork.SaveChangesAsync();

        }
        public async Task UpdateTeacher(Teacher teacher)
        {
            var teacherToUpdate = await _unitOfWork.GetRepository<Teacher>().GetById(teacher.Id);
            teacherToUpdate.NeptunCode = teacher.NeptunCode;
            teacherToUpdate.Name = teacher.Name;
            teacherToUpdate.title = teacher.title;

            _unitOfWork.GetRepository<Teacher>().Update(teacherToUpdate);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<Teacher> AddTeacher(Teacher teacher)
        {

            Teacher savedTeacher = await _unitOfWork.GetRepository<Teacher>().Create(teacher);
            await _unitOfWork.SaveChangesAsync();

            return savedTeacher;
        }
    }
}
