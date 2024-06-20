using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities.DAP
{
    public class DapNotes : BaseAuditableEntity
    {
        [Key]
        public int DapNoteId { get; set; }
        public int PatientId { get; set; }
        public int TherapistId { get; set; }
        public int OrganizationId { get; set; }
        public string Data { get; set; }
        public string Assessment { get; set; }
        public string Plans { get; set; }
    }
}
