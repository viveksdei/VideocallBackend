using Core.Domain.Entities.Patients;
using patient = Core.Domain.Entities.Patients.Patient;

namespace Core.Domain.Entities.VideoChat
{
    public class TeleSessionDetails :BaseAuditableEntity
    {
        public int Id { get; set; }

        public int TherapistId { get; set; }

        public int PatientID { get; set; }

        public string SessionID { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public Exception exception { get; set; }

        public int result { get; set; }

        public virtual patient Patient { get; set; }

        public int SlotId { get; set; }
        public PatientSessionSlotBooking PatientSessionSlotBooking { get; set; }

        public int OrganizationId { get; set; }
    }
}
