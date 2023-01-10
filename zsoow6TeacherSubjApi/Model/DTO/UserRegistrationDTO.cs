using System.ComponentModel.DataAnnotations;

namespace zsoow6TeacherSubjApi.Model.DTO
{
    public class UserRegistrationDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Name { get; set; }
        public string NeptunCode { get; set; }
        public string Department { get; set; } = "ismeretlen";
    }
}
