using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Review : BaseEntity
    {
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; } // من 1 إلى 5

        [MaxLength(500)]
        public string? Comment { get; set; }
        public Guid ReviewerId { get; set; }
        public ApplicationUser? Reviewer { get; set; }
        public Guid TargetUserId { get; set; }
        public ApplicationUser? TargetUser { get; set; }
    }
}
