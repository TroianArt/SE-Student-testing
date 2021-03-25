using System.Threading.Tasks;
using DAL.Domain;
using Microsoft.AspNetCore.Identity;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> SignUp(User user);

        Task SignIn(User user, bool isPersistant);

        Task<IdentityResult> ChangePassword(User user, string currentPassword, string newPassword);
    }
}