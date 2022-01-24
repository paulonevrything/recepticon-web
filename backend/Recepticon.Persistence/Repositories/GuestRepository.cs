using Recepticon.Domain.Guest;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recepticon.Persistence.Repositories
{
    public class GuestRepository : Repository<Guest>, IGuestRepository
    {
        public GuestRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
