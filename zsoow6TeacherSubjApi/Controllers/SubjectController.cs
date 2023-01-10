using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using zsoow6TeacherSubjApi.Model.DTO;
using zsoow6TeacherSubjApi.Model.Entity;
using zsoow6TeacherSubjApi.Services;

namespace zsoow6TeacherSubjApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize(Roles = "Admin,Teacher,Student")]
    public class SubjectController
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }
       


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task CreateSite(Subject subject)
        {
            await _subjectService.AddSubject(subject);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task UpdateSite(Subject subject)
        {
            await _subjectService.UpdateSubject(subject);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task DeleteSite(int id)
        {
            await _subjectService.DeleteSubject(id);
        }


        [HttpGet("{siteId}/{containDeleted}")]
        public List<StudentDTO> GetAllStudentBySemesterAndTeacher(int teacherId, int semesterId)
        {
            return _subjectService.GetAllStudentBySemesterAndTeacher(teacherId, semesterId);
        }

        [HttpGet("{teacherId}/{semesterId}")]
        public AggregatedSubjectDTO GetAggergatedSubjectBySemesterAndTeacher(int teacherId, int semesterId)
        {
            return _subjectService.GetAggergatedSubjectBySemesterAndTeacher(teacherId, semesterId);
        }

        [HttpGet("{teacherId}/{semesterId}")]
        public IQueryable<Subject> GetAllBySemesterAndStudent(int teacherId, int semesterId)
        {
            return _subjectService.GetAllBySemesterAndStudent(teacherId, semesterId);
        }
        [HttpGet("{teacherId}/{semesterId}")]
        public IQueryable<Subject> GetAllBySemesterAndTeacher(int teacherId, int semesterId)
        {
            return _subjectService.GetAllBySemesterAndTeacher(teacherId, semesterId);
        }

        [AllowAnonymous]
        [HttpGet("{containDeleted}")]
        public IQueryable<Subject> GetAll(bool containDeleted)
        {
            return _subjectService.GetAll(containDeleted);
        }

        [Authorize(Roles = "Student,Teacher", Policy = "Credit")]
        [HttpGet]
        public IEnumerable<Subject> GetAboveCredit()
        {
            return _subjectService.GetAboveCredit();
        }
    }
}
