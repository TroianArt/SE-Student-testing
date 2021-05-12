using BLL.Interfaces;
using DAL.Domain;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using System.Security.Claims;
using System;
using Serilog;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private string[] roles = {"Student", "Teacher", "Admin"};
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
            
            var result = await unitOfWork.UserManager.CreateAsync(userEntity, password);
            //await unitOfWork.UserManager.AddToRoleAsync(userEntity, "Student"); 
            Log.Logger.Verbose("Sign up user {@userdto} ", user);
            return result;
        }

        public async Task<IdentityResult> AddRole(UserDto user, string role)
        {
            var userEntity = unitOfWork.UserManager.FindByEmailAsync(user.Email);
            if (userEntity == null)
            {
                //return IdentityResult.Failed;
                Log.Logger.Warning("Not found user with email: {email} ", user.Email);
                return null;
            }

            bool roleExists = await unitOfWork.RoleManager.RoleExistsAsync(role);
            if (!roleExists && Array.Exists(roles, element => element == role))
            {
                await unitOfWork.RoleManager.CreateAsync(new Role(role));
            }

            var result = await unitOfWork.UserManager.AddToRoleAsync(userEntity.Result, role);
            Log.Logger.Verbose("Add role: {role} , User {@userdto} ", user,role);
            return result;
        }

        public async Task<SignInResult> SignInAsync(UserDto user, string password, bool isPersistant)
        {
            //var userEntity = mapper.Map<User>(user);
            var userEntity =await unitOfWork.UserManager.FindByEmailAsync(user.Email);
            if (userEntity != null)
            {
                var result = await unitOfWork.SignInManager.PasswordSignInAsync(userEntity, password, isPersistant, false);
                Log.Logger.Verbose("Signed in user {@user} ", user);
                return result;
            }
            else Log.Logger.Warning("already exists user with email: {email} ", user.Email);
            return null;
        }

        public async Task<IdentityResult> ChangePasswordAsync(string email, string currentPassword, string newPassword)
        {
            var userEntity = await unitOfWork.UserManager.FindByEmailAsync(email);
            var result = await unitOfWork.UserManager.ChangePasswordAsync(userEntity, currentPassword, newPassword);
            return result;
        }

        public Task SignOutAsync()
        {
            Log.Logger.Verbose("Sign out");
            return unitOfWork.SignInManager.SignOutAsync();
        }
    }
}