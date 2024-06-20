using Core.Domain._base;

namespace Infrastructure.Persistence.EfCoreData.Configurations
{
	public static class AuditableEntityTypeBuilderExtensions
	{
		public static void ConfigureBaseAuditableEntity<TEntity>(this EntityTypeBuilder<TEntity> builder)
			where TEntity : BaseAuditableEntity
		{
			builder.Property(e => e.IsDeleted);

			builder.Property(e => e.IsActive);

			builder.Property(e => e.CreatedBy)
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(e => e.CreatedOn)
				.HasColumnType("datetime");

			builder.Property(e => e.DeletedBy)
				.HasMaxLength(50);

			builder.Property(e => e.DeletedOn)
				.HasColumnType("datetime");

			builder.Property(e => e.LastModifiedBy)
				.HasMaxLength(50);

			builder.Property(e => e.LastModifiedOn)
				.HasColumnType("datetime");
		}
	}
}
