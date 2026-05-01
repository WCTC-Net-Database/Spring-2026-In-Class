namespace w14_doors.Models
{
    public interface ILockable
    {
        bool IsLocked { get; set; }
        bool IsTrapped { get; set; }
        bool IsPickable { get; set; }
        bool IsSecret { get; set; }
        string? RequiredKeyId { get; set; }
    }
}