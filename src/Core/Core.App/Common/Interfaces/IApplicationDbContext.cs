using Core.Domain.Entities.DAP;
using Core.Domain.Entities.Patient;
using Core.Domain.Entities.Patients;
using Core.Domain.Entities.SessionDetails;
using Core.Domain.Entities.SoapNotes;
using Core.Domain.Entities.VideoChat;
using System.Data;

namespace Core.App.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Patient> Patients { get; }
        DbSet<DealingIssueMapping> DealingIssueMapping { get; }
        DbSet<SessionsWeeksMapping> SessionsWeeksMapping { get; }
        DbSet<TherapySessionsSlotMapping> TherapySessionsSlotMapping { get; }
        DbSet<SessionDetail> SessionDetails { get; }
        DbSet<PatientSessionSlotBooking> PatientSessionSlotBooking { get; }
        DbSet<VideoConnectedUser> VideoConnectedUser { get; }
        DbSet<TeleHealthToken> TeleHealthToken { get; }
        DbSet<TeleSessionDetails> TeleSessionDetails { get; }
        DbSet<DapNotes> DapNotes { get; }
        DbSet<SoapNotes> SoapNotes { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
        IDbConnection GetConnection();
    }
}
