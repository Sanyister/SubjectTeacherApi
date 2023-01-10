using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Security.Claims;
using zsoow6TeacherSubjApi.Model.DTO;
using zsoow6TeacherSubjApi.Model.Entity;
using zsoow6TeacherSubjApi.Services;

namespace zsoow6TeacherSubjApi.Services
{
    public class UserService : IUserService
    {
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(RoleManager<IdentityRole<int>> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task InitRoles()
        {
            await CreateRole(Roles.ADMIN);
            await CreateRole(Roles.Teacher);
            await CreateRole(Roles.Student);

        }

        public async Task InitUsers()
        {
            await CreateUser("admin@test.com", "admin", new DateTime(2000, 1, 1), "qwertz", "ismeretlen", "admin admin","abc", Roles.ADMIN);
            await CreateUser("teacher@test.com", "teacher", new DateTime(1998, 05, 17), "1wert1", "VIRT", "teacher teacher", "abc", Roles.Teacher);
            await CreateUser("student@test.com", "student", new DateTime(1999, 01, 01), "2wert2", "ismeretlen", "student student", "abc", Roles.Student);
        }

        private async Task CreateUser(string email, string userName, DateTime dateOfBirth,
                                      string neptunCode, string department,string name,
                                      string password, string role)
        {
            ApplicationUser admin = new ApplicationUser()
            {
                UserName = userName,
                DateOfBirth = dateOfBirth,
                NeptunCode = neptunCode,
                Department = department,
                IsUser=true,
                Name=name

            };
            var user = await _userManager.CreateAsync(admin, password);
            if (user.Succeeded)
            {
                await _userManager.AddToRoleAsync(admin, role);
                await _userManager.AddClaimAsync(admin, new Claim(ClaimTypes.Role, role));
            }
        }
        private async Task CreateRole(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                await _roleManager.CreateAsync(new IdentityRole<int>(roleName));
            }
        }
    }
}
