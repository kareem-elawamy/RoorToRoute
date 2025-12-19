using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Auction : BaseEntity
    {
        [Required, MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal StartPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CurrentHighestBid { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public AuctionStatus Status { get; set; }
        ////
        public Guid CropId { get; set; }
        public Crop? Crop { get; set; }
        public ICollection<Bid>? Bids { get; set; }
    }
}