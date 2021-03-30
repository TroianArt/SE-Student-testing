using BLL.Interfaces;
using DAL.Domain;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public Task<IdentityResult> SignUpAsync(UserDto user)
        {
            var userEntity = mapper.Map<User>(user);
            return unitOfWork.UserManager.CreateAsync(userEntity);
        }

        public Task<SignInResult> SignInAsync(UserDto user, string password, bool isPersistant)
        {
            var userEntity = mapper.Map<User>(user);
            return unitOfWork.SignInManager.PasswordSignInAsync(userEntity,password,isPersistant,false);
        }

        public Task<IdentityResult> ChangePasswordAsync(UserDto user, string currentPassword, string newPassword)
        {
            var userEntity = mapper.Map<User>(user);
            return unitOfWork.UserManager.ChangePasswordAsync(userEntity, currentPassword, newPassword);
        }

        public Task SignOutAsync()
        {
            return unitOfWork.SignInManager.SignOutAsync();
        }
    }
}