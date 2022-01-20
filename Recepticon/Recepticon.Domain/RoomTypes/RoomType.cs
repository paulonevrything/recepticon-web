using Recepticon.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Recepticon.Domain.RoomTypes
{
    [Table("RoomTypes")]
    public class RoomType : DeleteEntity<int>
    {
        public string RoomTypeName { get; set; }
        public double Price { get; set; }
    }
}
