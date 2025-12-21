using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Bid : BaseEntity
    {
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public DateTime BidTime { get; set; }

        public Guid AuctionId { get; set; }
        public Auction? Auction { get; set; }

        public Guid BidderId { get; set; } // التاجر
        public ApplicationUser? Bidder { get; set; }
    }
}
