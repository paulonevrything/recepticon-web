using Recepticon.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recepticon.Domain.RoomTypes
{
    [Table("RoomTypes")]
    public class RoomType : DeleteEntity<int>
    {
        public string RoomTypeName { get; set; }
        public double Price { get; set; }
    }
}
