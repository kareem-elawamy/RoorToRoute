using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Chat : BaseEntity
    {
        public Guid SenderId { get; set; }
        public ApplicationUser? Sender { get; set; }
        public Guid ReceiverId { get; set; }
        public ApplicationUser? Receiver { get; set; }
        [Required]
        public string Message { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;


    }
}