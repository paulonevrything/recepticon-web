using System;
using System.ComponentModel.DataAnnotations.Schema;
using Recepticon.Domain.Base;
using Recepticon.Domain.RoomTypes;

namespace Recepticon.Domain.Rooms
{
    [Table("Rooms")]
    public class Room : DeleteEntity<int>
    {
        public int RoomTypeId { get; set; }
        [ForeignKey(nameof(RoomTypeId))]
        public virtual RoomType RoomType { get; set; }
        public string RoomNumber { get; set; }
        public RoomStatus RoomStatus { get; set; }
        public DateTime CheckOut { get; set; }
    }

    public enum RoomStatus
    {
        VACANT,
        OCCUPIED,
        OUT_OF_ORDER
    }
}
