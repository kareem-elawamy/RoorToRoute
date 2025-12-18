using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Farm : BaseEntity
    {
        public string? Name { get; set; } // اسم المزرعة
        public string? Location { get; set; } // موقع المزرعة
        public Guid OwnerId { get; set; } // معرف المالك (FK to User)
        public ApplicationUser? Owner { get; set; } // خاصية التنقل للمالك
        public ICollection<Crop>? Crops { get; set; } // المحاصيل في المزرعة
    }
}
