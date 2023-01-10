using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using zsoow6TeacherSubjApi.Model.Entity;
using zsoow6TeacherSubjApi.Services;


namespace zsoow6TeacherSubjApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize(Roles = "Admin,Teacher,Student")]
    public class SemesterController
    {
        private readonly ISemesterService _semesterService;
        public SemesterController(ISemesterService semesterService)
        {
            _semesterService = semesterService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task CreateSite(Semester semester)
        {
            await _semesterService.AddSemester(semester);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task UpdateSite(Semester semester)
        {
            await _semesterService.UpdateSemester(semester);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task DeleteSite(int id)
        {
            await _semesterService.DeleteSemester(id);
        }

        [AllowAnonymous]
        [HttpGet("{containDeleted}")]
        public IQueryable<Semester> GetAll(bool containDeleted)
        {
            return _semesterService.GetAll(containDeleted);
        }
    }
}
