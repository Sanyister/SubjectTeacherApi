using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace zsoow6TeacherSubjApi.Model.Entity
{
    /// <summary>
    /// ApplicationUser extends the IdentityUser with the required fields (related to task 10)
    /// IdentityUser<int> generate id from 1 to the user, otherwise id will be a guid
    /// </summary>
    public class ApplicationUser: IdentityUser<int>
    {
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string NeptunCode { get; set; }
        [Required]
        public bool IsUser { get; set; }
        [Required]
        public string Department { get; set; } = "ismeretlen";

    }
}
