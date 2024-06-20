using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Entities.SoapNotes
{
    public class SoapNotes :BaseAuditableEntity
    {
        [Key]
        public int SoapNoteId { get; set; }
        public int PatientId { get; set; }
        public int TherapistId { get; set; }
        public int OrganizationId { get; set; }
        public string Subjective { get; set; }
        public string Objective { get; set; }
        public string Assessment { get; set; }
        public string Plans { get; set; }
    }
}
