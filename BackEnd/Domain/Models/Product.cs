using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Product : MarketItem
    {
        public string? Barcode { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public WeightUnit? WeightUnit { get; set; }

        // التعديل: ربط المنتج بالمحصول الأصلي (اختياري)
        // اختياري ليه؟ عشان لو المنتج ده "مبيد حشري" بيبيعه تاجر، مش هيكون ليه CropId
        public Guid? SourceCropId { get; set; }
        // مش لازم Navigation Property (Crop) عشان منعملش Cycle، الـ ID كفاية للتتبع
    }
}
