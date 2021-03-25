using BLL.Interfaces;
using DAL.Domain;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<IdentityResult> ChangePassword(User user, string currentPassword, string newPassword)
        {
            throw new System.NotImplementedException();
        }

        public Task SignIn(User user, bool isPersistant)
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityResult> SignUp(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}