using Recepticon.Domain.Base;
using Recepticon.Domain.Rooms;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recepticon.Domain.Guest
{
    public class Guest : AuditEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int RoomId { get; set; }
        [ForeignKey(nameof(RoomId))]
        public virtual Room Room { get; set; }
    }
}
