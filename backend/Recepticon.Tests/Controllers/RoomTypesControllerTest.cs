using Microsoft.AspNetCore.Mvc;
using Moq;
using Recepticon.Api.Controllers;
using Recepticon.Core.Services.Interfaces;
using Recepticon.Domain.RoomTypes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Recepticon.Tests.Controllers
{
    public class RoomTypesControllerTest
    {
        private Mock<IRoomService> mockRoomService;
        private Mock<IRoomTypeRepository> mockRoomRepository;
        private RoomTypesController roomTypeController;

        public RoomTypesControllerTest()
        {
            mockRoomService = new Mock<IRoomService>();
            mockRoomRepository = new Mock<IRoomTypeRepository>();
            roomTypeController = new RoomTypesController(mockRoomService.Object);
        }


        [Fact]
        public async Task GetAllAsync_ReturnsAllRoomTypes()
        {
            var testResponseValue = GetAllRoomTypes();

            // Arrange
            mockRoomRepository.Setup(repo => repo.GetAll())
                .Returns(testResponseValue);

            mockRoomService.Setup(repo => repo.GetAllRoomTypes())
                .ReturnsAsync(testResponseValue);

            // Act
            var result = await roomTypeController.GetAllRoomTypesAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<RoomType>>(okResult.Value);
            var roomType = returnValue.FirstOrDefault();
            Assert.Equal(testResponseValue.FirstOrDefault(), roomType);
        }

        [Fact]
        public async Task CreateAsync_ReturnsNewlyCreatedGuest()
        {
            // Arrange
            var newRoomType = CreateRoomType();
            var testResponseValue = GetAllRoomTypes().FirstOrDefault();

            mockRoomService.Setup(repo => repo.CreateRoomType(newRoomType))
                .ReturnsAsync(testResponseValue);

            // Act
            var result = await roomTypeController.CreateAsync(newRoomType);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedRoomType = Assert.IsType<RoomType>(okResult.Value);

            Assert.Equal(newRoomType.RoomTypeName, returnedRoomType.RoomTypeName);
        }

        private IEnumerable<RoomType> GetAllRoomTypes()
        {
            var rommsTypes = new List<RoomType>()
            {
                new RoomType()
                {
                    Id = 1,
                    RoomTypeName = "Executive",
                    Price = 20000.00
                },

                new RoomType()
                {
                    Id = 2,
                    RoomTypeName = "Royal",
                    Price = 25000.00
                },

                new RoomType()
                {
                    Id = 3,
                    RoomTypeName = "VIP",
                    Price = 40000.00
                }
            };

            return rommsTypes;
        }

        private RoomType CreateRoomType()
        {
            var roomType = new RoomType()
            {
                Id = 1,
                RoomTypeName = "Executive",
                Price = 20000.00
            };

            return roomType;
        }
    }
}
