using AutoMapper;
using Recepticon.Domain.Models;
using Recepticon.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recepticon.Core.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDTO, User>();

        }
    }
}
