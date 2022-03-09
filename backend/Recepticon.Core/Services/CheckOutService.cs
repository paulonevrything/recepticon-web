using Microsoft.Extensions.Logging;
using Recepticon.Core.Services.Interfaces;
using Recepticon.Domain.Interfaces;
using Recepticon.Domain.Rooms;
using System;
using System.Threading.Tasks;

namespace Recepticon.Core.Services
{
    public class CheckOutService : ICheckOutService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IUnitOfWork _unitOfWork;
        readonly ILogger<CheckOutService> _logger;

        public CheckOutService(IRoomRepository roomRepository, IUnitOfWork unitOfWork,
            ILogger<CheckOutService> logger)
        {
            _roomRepository = roomRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<bool> CheckOut()
        {
            try
            {

                var todaysDate = DateTime.Today;

                var roomsDueForCheckout = _roomRepository.List(x => x.CheckOut.Date == todaysDate.Date && x.RoomStatus == RoomStatus.OCCUPIED);

                foreach (var room in roomsDueForCheckout)
                {
                    room.RoomStatus = RoomStatus.VACANT;
                    _roomRepository.Update(room);
                }

                await _unitOfWork.CommitAsync();

                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }


        }
    }
}
