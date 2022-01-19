using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Recepticon.Core.Services.Interfaces;
using Recepticon.Domain.Interfaces;
using Recepticon.Domain.Models;
using Recepticon.Domain.Users;

namespace Recepticon.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        readonly ILogger<UserService> _logger;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository,
            IMapper mapper, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            try
            {
                //TODO: Handle password encryption
                var userList = _userRepository.List(x => x.Username == username && x.Password == password).ToList();

                if (userList.Count < 1 || userList[0] == null)
                    return null;


                return userList[0];

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }

        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var userList = _userRepository.List(x => x.Id == id).ToList()   ;

                if (userList.Count > 1 || userList[0] != null)
                {
                    _userRepository.Delete(userList[0]);
                    await _unitOfWork.CommitAsync();

                    return true;
                }

                return false;

            } catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                var userList = _userRepository.GetAll().ToList();

                return userList;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<User> GetById(int id)
        {
            try
            {
                var userList = _userRepository.List(x => x.Id == id).ToList();

                if (userList.Count > 1 || userList[0] != null)
                {
                    return userList[0];

                }

                return null;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<User> Update(int id, User user)
        {
            try
            {
                var userList = _userRepository.List(x => x.Id == id).ToList();

                if (userList.Count > 1 || userList[0] != null)
                {
                    userList[0].FirstName = user.FirstName;
                    userList[0].LastName = user.LastName;
                    userList[0].Password = user.Password;
                    userList[0].Username = user.Username;
                    userList[0].Role = user.Role;

                    _userRepository.Update(userList[0]);
                    await _unitOfWork.CommitAsync();

                    return userList[0];

                }

                return null;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
