namespace Domain.Enums
{
    public enum CropStatus
    {
        Seeds, // بذور
        Growing, // نمو
        Harvested, // تم الحصاد (نهاية دورة حياة الـ Crop)
        Damaged, // تالف (لو باظ في الأرض)
    }
}
