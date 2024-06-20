using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Entities.Patients
{
    public class PatientSessionSlotBooking : BaseAuditableEntity
    {
        [Key]
        public int SlotId { get; set; }
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public int TherapistId { get; set; }
        public DateTime SlotDate { get; set; }

      
        public int SlotTimeId { get; set; }
   
        public virtual Patient Patient { get; set; }
        public int? StatusId { get; set; }
        public string? SessionId { get; set; }
        public string? Token { get; set; }
        public string? TokenClient { get; set; }

    }
}
