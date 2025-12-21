using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Crop : BaseEntity
    {
        public string? BatchNumber { get; set; } // رقم التشغيلة (للتتبع)
        public DateTime PlantedDate { get; set; }
        public DateTime? HarvestDate { get; set; }
        public CropStatus Status { get; set; }

        public bool IsForAuction { get; set; } // هل معروض للمزاد؟
        public bool IsForDirectSale { get; set; } // هل معروض للبيع المباشر؟

        public decimal? DirectSalePrice { get; set; } // السعر في حالة البيع المباشر
        public int AvailableQuantity { get; set; } // الكمية المتاحة بالكيلو/الطن

        public string? ImageUrl { get; set; } // صورة المحصول
        public Guid PlantInfoId { get; set; }
        public PlantInfo? PlantInfo { get; set; }
        public Guid FarmId { get; set; }
        public Farm? Farm { get; set; }
        public ICollection<CropActivityLog>? Activities { get; set; } = new List<CropActivityLog>();
    }
}
