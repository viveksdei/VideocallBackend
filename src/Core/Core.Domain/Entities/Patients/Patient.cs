using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Entities.Patients
{
    public class Patient : BaseAuditableEntity
    {
        [Key]
        public int PatientId { get; set; }
        [Column(TypeName = "varbinary(800)")]
        public byte[] FirstName { get; set; }
        [Column(TypeName = "varbinary(800)")]
        public byte[] LastName { get; set; }
        [Column(TypeName = "varbinary(1000)")]
        public byte[] Email { get; set; }
        [Column(TypeName = "varbinary(800)")]
        public byte[] Phone { get; set; }
    
        public int Gender { get; set; }
        public DateTime DOB { get; set; }
        public int TherapyType { get; set; }
        public int RelationshipStatus { get; set; }
        public int Preferlanguage { get; set; }
        [Column(TypeName = "varbinary(800)")]
        public byte[]? TherapyLanguageOther { get; set; }
        public int BeforeAnyTherapy { get; set; }
        [Column(TypeName = "varbinary(800)")]
        public byte[]? DealingIssueOther { get; set; }
        public int PasttwoWeeksStatus { get; set; }
        public int ImpTherapistBackground { get; set; }
        public int Religion { get; set; }
        public int ReligiousBeliefs { get; set; }
        public int PreferredCommunication { get; set; }
        [Column(TypeName = "varbinary(800)")]
        public byte[]? SeekingtherapyDescription { get; set; }
        [Column(TypeName = "varbinary(800)")]
        public byte[]? BeforeTherapyDescription { get; set; }
        [Column(TypeName = "varbinary(800)")]
        public byte[]? AdditionalDescription { get; set; }
       
        public int? TermsAndCondition { get; set; }
        public int UserId { get; set; }
        public int TherapistId { get; set; }=0;
        public int? StatusId { get; set; }
        public int? CountryId { get; set; }
        public int? TimeZoneId { get; set; }
    }
}
