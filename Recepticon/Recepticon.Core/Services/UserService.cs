using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BCryptNet = BCrypt.Net.BCrypt;
using Microsoft.Extensions.Logging;
using Recepticon.Core.Services.Interfaces;
using Recepticon.Domain.Interfaces;
using Recepticon.Domain.Models;
using Recepticon.Domain.Users;
using System.Linq.Expressions;
using Recepticon.Core.Helpers;

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

                var existingUsers = _userRepository.List(x => x.Username == username && x.Password == BCryptNet.HashPassword(password)).ToList();

                return existingUsers[0];

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }

        }

        public void Create(UserDTO model)
        {
            try
            {
                var existingUsers = _userRepository.List(x => x.Username == model.Username).ToList();

                if (existingUsers.Count > 0)
                    throw new CustomException("User with the email '" + model.Username + "' already exists");

                var user =_mapper.Map<User>(model);

                user.Password = BCryptNet.HashPassword(model.Password);

                _userRepository.Add(user);
                _unitOfWork.CommitAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var existngUser = GetUser(id);

                _userRepository.Delete(existngUser);
                await _unitOfWork.CommitAsync();

                return true;

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

                return GetUser(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<User> Update(int id, UserDTO user)
        {
            try
            {
                var existingUser = GetUser(id);

                if (existingUser != null)
                {
                    existingUser.FirstName = user.FirstName;
                    existingUser.LastName = user.LastName;
                    existingUser.Password = user.Password;
                    existingUser.Username = user.Username;
                    existingUser.Role = user.Role;

                    _userRepository.Update(existingUser);
                    await _unitOfWork.CommitAsync();

                    return existingUser;

                }

                return null;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        private User GetUser(int id)
        {
            var user = _userRepository.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
    }
}
