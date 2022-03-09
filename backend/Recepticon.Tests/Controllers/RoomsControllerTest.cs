using Microsoft.AspNetCore.Mvc;
using Moq;
using Recepticon.Api.Controllers;
using Recepticon.Core.Services.Interfaces;
using Recepticon.Domain.Models;
using Recepticon.Domain.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Recepticon.Tests.Controllers
{
    public class RoomsControllerTest
    {
        private Mock<IRoomService> mockRoomService;
        private Mock<IRoomRepository> mockRoomRepository;
        private RoomsController roomController;

        public RoomsControllerTest()
        {
            mockRoomService = new Mock<IRoomService>();
            mockRoomRepository = new Mock<IRoomRepository>();
            roomController = new RoomsController(mockRoomService.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllRooms()
        {
            var testResponseValue = GetAllRooms();

            // Arrange
            mockRoomRepository.Setup(repo => repo.GetAll())
                .Returns(testResponseValue);

            mockRoomService.Setup(repo => repo.GetAllRooms())
                .ReturnsAsync(testResponseValue);

            // Act
            var result = await roomController.GetAllRoomsAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Room>>(okResult.Value);
            var room = returnValue.FirstOrDefault();
            Assert.Equal(testResponseValue.FirstOrDefault(), room);
        }

        [Fact]
        public async Task CreateAsync_ReturnsNewlyCreatedGuest()
        {
            // Arrange
            var newRoom = CreateRoom();
            var testResponseValue = GetAllRooms().FirstOrDefault();

            mockRoomService.Setup(repo => repo.CreateRoom(newRoom))
                .ReturnsAsync(testResponseValue);

            // Act
            var result = await roomController.CreateAsync(newRoom);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedRoom = Assert.IsType<Room>(okResult.Value);

            Assert.Equal(newRoom.RoomNumber, returnedRoom.RoomNumber);
        }


        private IEnumerable<Room> GetAllRooms()
        {
            var rommsTypes = new List<Room>()
            {
                new Room()
                {
                    Id = 1,
                    RoomNumber = "210",
                    RoomStatus = RoomStatus.VACANT,
                    RoomTypeId = 2,
                    CheckOut = DateTime.Now
                },

                new Room()
                {
                    Id = 2,
                    RoomNumber = "200",
                    RoomStatus = RoomStatus.OCCUPIED,
                    RoomTypeId = 1,
                    CheckOut = DateTime.Now.AddDays(3)
                },

                new Room()
                {
                    Id = 3,
                    RoomNumber = "300",
                    RoomStatus = RoomStatus.OCCUPIED,
                    RoomTypeId = 2,
                    CheckOut = DateTime.Now.AddDays(1)
                }
            };

            return rommsTypes;
        }

        private RoomDTO CreateRoom()
        {
            var roomDTO = new RoomDTO()
            {
                RoomNumber = "210",
                RoomTypeId = 2,
            };

            return roomDTO;
        }
    }
}
