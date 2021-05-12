using System.Threading.Tasks;
using BLL.DTO;
using DAL.Domain;
using Microsoft.AspNetCore.Identity;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> SignUpAsync(UserDto user, string password);

        public Task<SignInResult> SignInAsync(UserDto user, string password, bool isPersistant);

        Task<IdentityResult> ChangePasswordAsync(string email, string currentPassword, string newPassword);

        Task SignOutAsync();

        public Task<IdentityResult> AddRole(UserDto user, string role);
    }
}