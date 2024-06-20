namespace Core.Domain._base
{
    public abstract class BaseAuditableEntity
    {
		public bool IsDeleted { get; set; } = false;
		public bool IsActive { get; set; } = true;
		public string CreatedBy { get; set; }
		public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
		public string? LastModifiedBy { get; set; }
		public DateTime? LastModifiedOn { get; set; }
		public string? DeletedBy { get; set; }
		public DateTime? DeletedOn { get; set; }
	}
}
