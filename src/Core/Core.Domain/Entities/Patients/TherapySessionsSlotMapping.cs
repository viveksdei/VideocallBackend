using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities.Patient
{
    public class TherapySessionsSlotMapping : BaseAuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int SlotId { get; set; }
    }
}
