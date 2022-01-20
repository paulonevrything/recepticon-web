﻿using Recepticon.Domain.Guest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recepticon.Core.Services.Interfaces
{
    public interface IGuestService
    {
        Task<Guest> Create(Guest model);
        Task<IEnumerable<Guest>> GetAll();
        Task<Guest> GetById(int id);
        Task<Guest> Update(int id, Guest user);
    }
}
