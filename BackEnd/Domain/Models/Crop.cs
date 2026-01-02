using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Crop : BaseEntity
    {
        [Required]
        public string BatchNumber { get; set; } = Guid.NewGuid().ToString().Substring(0, 8);

        public CropStatus Status { get; set; } = CropStatus.Seeds;

        public double PlantedArea { get; set; } // بالمتر المربع
        public DateTime PlantingDate { get; set; }
        public DateTime? ExpectedHarvestDate { get; set; }

        // البيانات المرجعية
        public Guid PlantInfoId { get; set; }
        public PlantInfo? PlantInfo { get; set; }

        // المكان
        public Guid FarmId { get; set; }
        public Farm? Farm { get; set; }

        public ICollection<CropActivityLog> Activities { get; set; } = new List<CropActivityLog>();
    }
}
