using AutoMapper;
using Microsoft.Extensions.Logging;
using Recepticon.Core.Constants;
using Recepticon.Core.Exceptions;
using Recepticon.Core.Helpers;
using Recepticon.Core.Services.Interfaces;
using Recepticon.Domain.Interfaces;
using Recepticon.Domain.Models;
using Recepticon.Domain.Rooms;
using Recepticon.Domain.RoomTypes;
using Recepticon.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recepticon.Core.Services
{
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoomRepository _roomRepository;
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly IMapper _mapper;
        readonly ILogger<RoomService> _logger;

        public RoomService(IUnitOfWork unitOfWork, IRoomRepository roomRepository,
            ILogger<RoomService> logger, IMapper mapper, IRoomTypeRepository roomTypeRepository)
        {
            _roomRepository = roomRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _roomTypeRepository = roomTypeRepository;
        }
        public async Task<Room> CreateRoom(RoomDTO model)
        {
            try
            {
                var existingRoom = _roomRepository.List(x => x.RoomNumber == model.RoomNumber).FirstOrDefault();

                if (existingRoom != null)
                    throw new AlreadyExistException("Room with the room number '" + model.RoomNumber + "' already exists");

                var room = _mapper.Map<Room>(model);
                room.RoomStatus = RoomStatus.VACANT;

                _roomRepository.Add(room);
                await _unitOfWork.CommitAsync();

                return room;

            }
            catch (Exception ex)
            {
                throw ThrowException(ex);
            }
        }

        public async Task<bool> DeleteRoom(int id)
        {
            try
            {
                var existingRoom = GetRoom(id);

                _roomRepository.Delete(existingRoom);
                await _unitOfWork.CommitAsync();

                return true;

            }
            catch (Exception ex)
            {
                throw ThrowException(ex);
            }
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            try
            {
                var rooms = _roomRepository.GetAll().ToList();

                return rooms;

            }
            catch (Exception ex)
            {
                throw ThrowException(ex);
            }
        }

        public async Task<IEnumerable<Room>> GetAllVacantRooms()
        {
            try
            {
                var rooms = _roomRepository.List(x => x.RoomStatus == RoomStatus.VACANT).ToList();

                return rooms;

            }
            catch (Exception ex)
            {
                throw ThrowException(ex);
            }
        }

        public async Task<Room> GetRoomById(int id)
        {
            try
            {
                return GetRoom(id);
            }
            catch (Exception ex)
            {
                throw ThrowException(ex);
            }
        }

        public async Task<Room> UpdateRoom(int id, Room room)
        {
            try
            {
                var existingRoom = GetRoom(id);

                existingRoom.RoomStatus = room.RoomStatus;
                existingRoom.RoomTypeId = room.RoomTypeId;
                existingRoom.RoomNumber = room.RoomNumber;

                _roomRepository.Update(existingRoom);
                await _unitOfWork.CommitAsync();

                return existingRoom;

            }
            catch (Exception ex)
            {
                throw ThrowException(ex);
            }
        }


        public async Task<RoomType> CreateRoomType(RoomType model)
        {
            try
            {
                var existingRoomType = _roomTypeRepository.List(x => x.RoomTypeName == model.RoomTypeName).FirstOrDefault();

                if (existingRoomType != null)
                    throw new AlreadyExistException("Room type with the name '" + model.RoomTypeName + "' already exists");

                _roomTypeRepository.Add(model);
                await _unitOfWork.CommitAsync();

                return model;

            }
            catch (Exception ex)
            {
                throw ThrowException(ex);
            }
        }

        public async Task<bool> DeleteRoomType(int id)
        {
            try
            {
                var existingRoomType = GetRoomType(id);

                _roomTypeRepository.Delete(existingRoomType);
                await _unitOfWork.CommitAsync();

                return true;

            }
            catch (Exception ex)
            {
                throw ThrowException(ex);
            }
        }

        public async Task<IEnumerable<RoomType>> GetAllRoomTypes()
        {
            try
            {
                var roomTypes = _roomTypeRepository.GetAll().ToList();

                return roomTypes;

            }
            catch (Exception ex)
            {
                throw ThrowException(ex);
            }
        }

        public async Task<RoomType> GetRoomTypeById(int id)
        {
            try
            {
                return GetRoomType(id);
            }
            catch (Exception ex)
            {
                throw ThrowException(ex);
            }
        }

        public async Task<RoomType> UpdateRoomType(int id, RoomType roomType)
        {
            try
            {
                var existingRoomType = GetRoomType(id);

                existingRoomType.Price = roomType.Price;
                existingRoomType.RoomTypeName = roomType.RoomTypeName;

                _roomTypeRepository.Update(existingRoomType);
                await _unitOfWork.CommitAsync();

                return existingRoomType;

            }
            catch (Exception ex)
            {
                throw ThrowException(ex);
            }
        }

        private Room GetRoom(int id)
        {
            var room = _roomRepository.Find(id);
            if (room == null) throw new KeyNotFoundException(ErrorConstants.ROOM_NOT_FOUND);
            return room;
        }

        private RoomType GetRoomType(int id)
        {
            var roomType = _roomTypeRepository.Find(id);
            if (roomType == null) throw new KeyNotFoundException(ErrorConstants.ROOM_TYPE_NOT_FOUND);
            return roomType;
        }

        private Exception ThrowException(Exception ex)
        {
            _logger.LogError(ex.Message);

            if (ex.InnerException is KeyNotFoundException)
            {
                return ex;
            }

            return new CustomException(ErrorConstants.UNKNOWN_ERROR);
        }
    }
}
