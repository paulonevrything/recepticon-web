using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var userList = _userRepository.List(x => x.Username == username && x.Password == password).ToList();

            if (userList.Count < 1 || userList[0] == null)
                return null;

            //var user = _mapper.Map<UserDTO>(userList[0]);

            return userList[0]; 
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
