using Core.App.Common.Interfaces;
using Core.Domain.Entities.DAP;
using Core.Domain.Entities.Patient;
using Core.Domain.Entities.Patients;
using Core.Domain.Entities.SessionDetails;
using Core.Domain.Entities.SoapNotes;
using Core.Domain.Entities.VideoChat;
using System.Data;
using System.Reflection;

namespace Infrastructure.Persistence.EfCoreData
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        //Non-Master
        public DbSet<Patient> Patients => Set<Patient>();

        public DbSet<TherapySessionsSlotMapping> TherapySessionsSlotMapping => Set<TherapySessionsSlotMapping>();
        public DbSet<SessionsWeeksMapping> SessionsWeeksMapping => Set<SessionsWeeksMapping>();
        public DbSet<DealingIssueMapping> DealingIssueMapping => Set<DealingIssueMapping>();
        public DbSet<SessionDetail> SessionDetails => Set<SessionDetail>();
        public DbSet<PatientSessionSlotBooking> PatientSessionSlotBooking => Set<PatientSessionSlotBooking>();
        public DbSet<VideoConnectedUser> VideoConnectedUser => Set<VideoConnectedUser>();
        public DbSet<TeleSessionDetails> TeleSessionDetails => Set<TeleSessionDetails>();
        public DbSet<TeleHealthToken> TeleHealthToken => Set<TeleHealthToken>();
        public DbSet<DapNotes> DapNotes => Set<DapNotes>();
        public DbSet<SoapNotes> SoapNotes => Set<SoapNotes>();


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("app");
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public IDbConnection GetConnection()
        {
            var connection = Database.GetDbConnection();
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }
    }
}
