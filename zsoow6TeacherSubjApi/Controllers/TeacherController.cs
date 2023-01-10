using System.Security.Policy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using zsoow6TeacherSubjApi.Model.Entity;
using zsoow6TeacherSubjApi.Services;

namespace zsoow6TeacherSubjApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize(Roles = "Admin,Teacher,Student")]
    public class TeacherController:Controller
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task CreateSite(Teacher teacher)
        {
            await _teacherService.AddTeacher(teacher);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task UpdateSite(Teacher teacher)
        {
            await _teacherService.UpdateTeacher(teacher);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task DeleteSite(int id)
        {
            await _teacherService.DeleteTeacher(id);
        }

        [AllowAnonymous]
        [HttpGet("{containDeleted}")]
        public IQueryable<Teacher> GetAll(bool containDeleted)
        {
            return _teacherService.GetAll(containDeleted);
        }
    }
}
