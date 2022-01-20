using Microsoft.Extensions.Logging;
using Recepticon.Core.Services.Interfaces;
using Recepticon.Domain.Guest;
using Recepticon.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recepticon.Core.Services
{
    public class GuestService : IGuestService
    {
        private IGuestRepository _guestRepository;
        private readonly IUnitOfWork _unitOfWork;
        readonly ILogger<GuestService> _logger;
        public GuestService(IGuestRepository guestRepository, IUnitOfWork unitOfWork, ILogger<GuestService> logger)
        {
            _guestRepository = guestRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<Guest> Create(Guest model)
        {
            try
            {
                /* TODO: Clean out guest creation
                     check that room is available
                     check that checkout date is after checkin date and is not same day
                     create guest
                     update room status and checkout date
                */

                _guestRepository.Add(model);
                await _unitOfWork.CommitAsync();

                return model;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
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
                _logger.LogError(ex.Message);
                throw;
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

                if (existingGuest != null)
                {
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

                return null;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        private Guest GetGuest(int id)
        {
            var guest = _guestRepository.Find(id);
            if (guest == null) throw new KeyNotFoundException("Guest not found");
            return guest;
        }
    }
}
