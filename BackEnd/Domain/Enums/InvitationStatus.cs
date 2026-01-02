namespace Domain.Enums
{
    public enum InvitationStatus
    {
        Pending, // تم الإرسال وفي الانتظار
        Accepted, // قبل الدعوة (وقتها بنحوله لـ Member)
        Rejected, // رفض الدعوة
        Expired, // الوقت عدى
    }
}
