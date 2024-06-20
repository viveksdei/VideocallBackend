//namespace Infrastructure.Persistence.EfCoreData.Configurations.Patient
//{
//	public class PatientConfiguration : IEntityTypeConfiguration<Core.Domain.Entities.Patient.Patient>
//	{
//		public void Configure(EntityTypeBuilder<Core.Domain.Entities.Patient.Patient> builder)
//		{
//			// Configure table name
//			builder.ToTable(name: "Patient", schema: "dbo").HasKey(x => x.PatientId);
//			builder.Property(p => p.PatientId).UseIdentityColumn();

//			// Configure table columns 

//			builder.Property(e => e.Gender)
//				.HasMaxLength(50);

//			//Configure baseAuditableEntity
//			builder.ConfigureBaseAuditableEntity();

//			// Configure indexes
//		}
//	}
//}
