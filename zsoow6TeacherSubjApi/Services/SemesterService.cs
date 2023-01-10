using zsoow6TeacherSubjApi.UnitOfWork;
using zsoow6TeacherSubjApi.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace zsoow6TeacherSubjApi.Services
{
    public class SemesterService: ISemesterService
    {
        public SemesterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        private readonly IUnitOfWork _unitOfWork;
        public IQueryable<Semester> GetAll(bool containDeleted)
        {
            return GetBasedOnContainDeleted(containDeleted);
        }
        private IQueryable<Semester> GetBasedOnContainDeleted(bool containDeleted)
        {
            return containDeleted ? _unitOfWork.GetRepository<Semester>().GetAll().IgnoreQueryFilters() : _unitOfWork.GetRepository<Semester>().GetAll();
            //return containDeleted ? _trainCarAPIDbContext.Set<RollingStock>().IgnoreQueryFilters() : _trainCarAPIDbContext.Set<RollingStock>();
        }

        public async Task DeleteSemester(int id)
        {
            var semesterToDelete = await _unitOfWork.GetRepository<Semester>().GetById(id);

            semesterToDelete.Deleted = true;
            _unitOfWork.GetRepository<Semester>().Update(semesterToDelete);
            await _unitOfWork.SaveChangesAsync();

        }
        public async Task UpdateSemester(Semester semester)
        {
            var semesterToUpdate = await _unitOfWork.GetRepository<Semester>().GetById(semester.Id);
            semesterToUpdate.Name = semester.Name;
            semesterToUpdate.StartDate = semester.StartDate;
            semesterToUpdate.EndDate = semester.EndDate;
            semesterToUpdate.Subjects = semester.Subjects;
            _unitOfWork.GetRepository<Semester>().Update(semesterToUpdate);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<Semester> AddSemester(Semester semester)
        {
            Semester savedSemester = await _unitOfWork.GetRepository<Semester>().Create(semester);
            await _unitOfWork.SaveChangesAsync();

            return savedSemester;
        }
    }
}
