using Moq;
using Recepticon.Api.Controllers;
using Recepticon.Core.Services.Interfaces;
using Recepticon.Domain.Rooms;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
