using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public decimal TotalAmount { get; set; }

        // من المشتري؟ (ممكن يكون مستخدم عادي أو مصنع)
        public Guid BuyerId { get; set; }
        public ApplicationUser? Buyer { get; set; }
        public OrderStatus Status { get; set; } // Pending, Shipped, Delivered

        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
