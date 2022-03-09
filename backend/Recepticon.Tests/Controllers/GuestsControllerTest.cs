using Microsoft.AspNetCore.Mvc;
using Moq;
using Recepticon.Api.Controllers;
using Recepticon.Core.Services.Interfaces;
using Recepticon.Domain.Guest;
using Recepticon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Recepticon.Tests.Controllers
{
    public class GuestsControllerTest
    {
        private Mock<IGuestService> mockGuestService;
        private Mock<IGuestRepository> mockGuestRepository;
        private GuestsController guestsController;

        public GuestsControllerTest()
        {
            mockGuestService = new Mock<IGuestService>();
            mockGuestRepository = new Mock<IGuestRepository>();
            guestsController = new GuestsController(mockGuestService.Object);
        }


        [Fact]
        public async Task GetAllAsync_ReturnsAllGuests()
        {
            var testResponseValue = GetAllGuests();

            // Arrange
            mockGuestRepository.Setup(repo => repo.GetAll())
                .Returns(testResponseValue);

            mockGuestService.Setup(repo => repo.GetAll())
                .ReturnsAsync(testResponseValue);

            // Act
            var result = await guestsController.GetAllAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Guest>>(okResult.Value);
            var guest = returnValue.FirstOrDefault();
            Assert.Equal(testResponseValue.FirstOrDefault(), guest);
        }

        [Fact]
        public async Task CreateAsync_ReturnsNewlyCreatedGuest()
        {
            // Arrange
            var newGuest = CreateNewGuest();
            var testResponseValue = GetAllGuests().FirstOrDefault();

            mockGuestService.Setup(repo => repo.Create(newGuest))
                .ReturnsAsync(testResponseValue);

            // Act
            var result = await guestsController.CreateAsync(newGuest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedGuest = Assert.IsType<Guest>(okResult.Value);

            Assert.Equal(newGuest.FirstName, returnedGuest.FirstName);
        }

        private IEnumerable<Guest> GetAllGuests()
        {
            var guests = new List<Guest>()
            {
                new Guest()
                {
                    FirstName = "Damian",
                    LastName = "Ronaldo",
                    Address = "Broad Street, Lagos Island",
                    PhoneNumber = "08031234567",
                    RoomId = 5,
                    CheckIn = DateTime.Now,
                    CheckOut = DateTime.Now.AddDays(3)
                },

                new Guest()
                {
                    FirstName = "Robin",
                    LastName = "Okocha",
                    Address = "Oshodi Under Bridge",
                    PhoneNumber = "08031234567",
                    RoomId = 10,
                    CheckIn = DateTime.Now.AddDays(3),
                    CheckOut = DateTime.Now.AddDays(5)
                }
            };

            return guests;
        }

        private GuestDTO CreateNewGuest()
        {
            var newGuest = new GuestDTO()
            {
                FirstName = "Damian",
                LastName = "Ronaldo",
                Address = "Broad Street, Lagos Island",
                PhoneNumber = "08031234567",
                RoomId = 5,
                CheckIn = DateTime.Now,
                CheckOut = DateTime.Now.AddDays(3)
            };

            return newGuest;
        }
    }
}
