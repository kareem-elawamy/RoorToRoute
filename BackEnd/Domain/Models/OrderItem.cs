using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class OrderItem: BaseEntity
    {
        public Guid OrderId { get; set; }
        public Order? Order { get; set; }

        public Guid CropId { get; set; }
        public Crop? Crop { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}