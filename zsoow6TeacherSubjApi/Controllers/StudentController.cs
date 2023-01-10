using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using zsoow6TeacherSubjApi.Model.Entity;
using zsoow6TeacherSubjApi.Services;

namespace zsoow6TeacherSubjApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize(Roles = "Admin,Teacher,Student")]
    public class StudentController
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task CreateSite(Student student)
        {
            await _studentService.AddStudent(student);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task UpdateSite(Student student)
        {
            await _studentService.UpdateStudent(student);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task DeleteSite(int id)
        {
            await _studentService.DeleteStudent(id);
        }

        [AllowAnonymous]
        [HttpGet("{containDeleted}")]
        public IQueryable<Student> GetAll(bool containDeleted)
        {
            return _studentService.GetAll(containDeleted);
        }
    }
}
