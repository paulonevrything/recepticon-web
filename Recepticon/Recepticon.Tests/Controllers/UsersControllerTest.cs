using Microsoft.AspNetCore.Mvc;
using Moq;
using Recepticon.Api.Controllers;
using Recepticon.Core.Services.Interfaces;
using Recepticon.Domain.Models;
using Recepticon.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Recepticon.Tests.Controllers
{
    public class UsersControllerTest
    {
        private Mock<IUserService> mockUserService;
        private Mock<IUserRepository> mockUserRepository;
        private UsersController usersController;

        public UsersControllerTest()
        {
            mockUserService = new Mock<IUserService>();
            mockUserRepository = new Mock<IUserRepository>();
            usersController = new UsersController(mockUserService.Object);
        }



        [Fact]
        public async Task GetAllAsync_ReturnsAllUsers()
        {
            var testResponseValue = GetAllUsers();
           
            // Arrange
            mockUserRepository.Setup(repo => repo.GetAll())
                .Returns(testResponseValue);

            mockUserService.Setup(repo => repo.GetAll())
                .ReturnsAsync(testResponseValue);

            // Act
            var result = await usersController.GetAllAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<User>>(okResult.Value);
            var user = returnValue.FirstOrDefault();
            Assert.Equal(testResponseValue.FirstOrDefault(), user);
        }

        [Fact]
        public async Task GetOneAsync_ShouldReturnOneUser()
        {
            var testResponseValue = GetAllUsers().FirstOrDefault();

            // Arrange
            mockUserRepository.Setup(repo => repo.Find(1))
                .Returns(testResponseValue);

            mockUserService.Setup(repo => repo.GetById(1))
                .ReturnsAsync(testResponseValue);

            // Act
            var result = await usersController.GetByIdAsync(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<User>(okResult.Value);
            Assert.Equal(testResponseValue, returnValue);
        }

        [Fact]
        public async Task GetOneAsync_ReturnsNotFoundResult_ForInvalidUserId()
        {

            // Arrange
            mockUserRepository.Setup(repo => repo.Find(3))
                .Returns((User)null);

            mockUserService.Setup(repo => repo.GetById(3))
                .ReturnsAsync((User)null);

            // Act
            var result = await usersController.GetByIdAsync(3);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task CreateAsync_ReturnsNewlyCreatedUser()
        {
            // Arrange
            var userToBeCreated = CreateNewUser();
            var testResponseValue = GetAllUsers().FirstOrDefault();

            mockUserService.Setup(repo => repo.Create(userToBeCreated))
                .ReturnsAsync(testResponseValue);

            // Act
            var result = await usersController.CreateAsync(userToBeCreated);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedUser = Assert.IsType<User>(okResult.Value);

            Assert.Equal(userToBeCreated.FirstName, returnedUser.FirstName);
        }

        private IEnumerable<User> GetAllUsers()
        {
            var users = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Username = "john-doe",
                    Role = Role.RECEPTIONIST
                },

                new User()
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Doe",
                    Username = "jane-doe",
                    Role = Role.ADMIN
                }
            };

            return users;
        }

        private UserDTO CreateNewUser()
        {
            var userToBeCreated = new UserDTO()
            {
                FirstName = "John",
                LastName = "Doe",
                Username = "john-doe",
                Password = "qwertyuiop",
                ConfirmPassword = "qwertyuiop",
                Role = Role.RECEPTIONIST
            };

            return userToBeCreated;
        }
    }
}
