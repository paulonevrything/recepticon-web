using AutoMapper;
using Microsoft.Extensions.Logging;
using Recepticon.Core.Constants;
using Recepticon.Core.Exceptions;
using Recepticon.Core.Services.Interfaces;
using Recepticon.Domain.Guest;
using Recepticon.Domain.Interfaces;
using Recepticon.Domain.Models;
using Recepticon.Domain.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recepticon.Core.Services
{
    public class GuestService : IGuestService
    {
        private IGuestRepository _guestRepository;
        private readonly IUnitOfWork _unitOfWork;
        readonly ILogger<GuestService> _logger;
        private readonly IMapper _mapper;
        private IRoomRepository _roomRepository;
        
        public GuestService(IGuestRepository guestRepository, IUnitOfWork unitOfWork,
            ILogger<GuestService> logger, IMapper mapper, IRoomRepository roomRepository)
        {
            _guestRepository = guestRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _roomRepository = roomRepository;
        }

        public async Task<Guest> Create(GuestDTO model)
        {
            try
            {

                if(model.CheckOut.Date <= model.CheckIn.Date)
                {
                    throw new InvalidCheckInAndCheckOutException(ErrorConstants.INVALID_CHECKIN_AND_CHECKOUT, new InvalidCheckInAndCheckOutException());
                }

                var room = _roomRepository.Find(model.RoomId);

                if(room == null || room.RoomStatus != RoomStatus.VACANT)
                {
                    throw new OccupiedRoomException($"Room { model.RoomId } is not available at the moment", new OccupiedRoomException());

                } else
                {
                    room.RoomStatus = RoomStatus.OCCUPIED;
                    room.CheckOut = model.CheckOut;
                    _roomRepository.Update(room);
                }

                var guest = _mapper.Map<Guest>(model);

                _guestRepository.Add(guest);
                await _unitOfWork.CommitAsync();

                return guest;

            }
            catch (Exception ex)
            {
                throw ErrorConstants.ThrowException(ex, _logger);
            }
        }

        public async Task<IEnumerable<Guest>> GetAll()
        {
            try
            {

                return _guestRepository.GetAll().ToList();

            }
            catch (Exception ex)
            {
                throw ErrorConstants.ThrowException(ex, _logger);
            }
        }

        public async Task<Guest> GetById(int id)
        {
            return GetGuest(id);
        }

        public async Task<Guest> Update(int id, Guest model)
        {
            try
            {
                var existingGuest = GetGuest(id);

                existingGuest.FirstName = model.FirstName;
                existingGuest.LastName = model.LastName;
                existingGuest.PhoneNumber = model.PhoneNumber;
                existingGuest.Address = model.Address;
                existingGuest.CheckIn = model.CheckIn;
                existingGuest.CheckOut = model.CheckOut;

                _guestRepository.Update(existingGuest);
                await _unitOfWork.CommitAsync();

                return existingGuest;

            }
            catch (Exception ex)
            {
                throw ErrorConstants.ThrowException(ex, _logger);
            }
        }

        private Guest GetGuest(int id)
        {
            var guest = _guestRepository.Find(id);
            if (guest == null) throw new KeyNotFoundException(ErrorConstants.GUEST_NOT_FOUND, new KeyNotFoundException());
            return guest;
        }
    }
}
