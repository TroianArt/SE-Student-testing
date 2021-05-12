using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using student_testing.Controllers;
using System;
using Xunit;
namespace Tests
{
    public class Tests
    {
        private readonly AuthController _authController;
        private readonly Mock<IUserService> _userService;
        private IUnitOfWork unitOfWork = new UnitOfWork();

        public Tests()
        {
            _userService = new Mock<IUserService>();
            _authController = new AuthController(_userService.Object);
        }
        public UserDto userDto = new UserDto()
        {
            Id = "1",
            UserName = "user_name",
            Email = "user@gmail.com",
            UserTests = null,
            Answers = null,
            Groups = null,
            Roles = null
        };
      
        [Fact]
        public void TestSignIn()
        {
            String password = "1234#Oleg";
            bool isPersistant = true;
            _userService.Setup(x => x.SignInAsync(It.IsAny<UserDto>(), password, isPersistant));

            var result = _authController.Login();
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void TestSignUp()
        {
            String password = "1234#Oleg";
            _userService.Setup(x => x.SignUpAsync(It.IsAny<UserDto>(), password));
            var result = _authController.SignUp();

            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

    }
}
