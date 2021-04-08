using BLL.Interfaces;
using DAL.Domain;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using System.Security.Claims;
using System;

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

        public async Task<IdentityResult> SignUpAsync(UserDto user, string password)
        {
            var userEntity = mapper.Map<User>(user);
            userEntity.Id = Guid.NewGuid().ToString();
            unitOfWork.UserManager.AddToRoleAsync(userEntity, "Student");
            var result = await unitOfWork.UserManager.CreateAsync(userEntity, password);
            return result;
        }

        public async Task<IdentityResult> AddRole(UserDto user, string role)
        {
            var userEntity = unitOfWork.UserManager.FindByEmailAsync(user.Email);
            var result = await unitOfWork.UserManager.AddToRoleAsync(userEntity.Result, role);
            return result;
        }

        public async Task<SignInResult> SignInAsync(UserDto user, string password, bool isPersistant)
        {
            //var userEntity = mapper.Map<User>(user);
            var userEntity = unitOfWork.UserManager.FindByEmailAsync(user.Email);
            if (userEntity.Result != null)
            {
                var result = await unitOfWork.SignInManager.PasswordSignInAsync(userEntity.Result, password, isPersistant, false);
                return result;
            }
            return null;
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