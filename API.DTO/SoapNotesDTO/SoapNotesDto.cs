using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.DTO.SoapNotesDTO
{
    public class SoapNotesDto
    {
        public int SoapNoteId { get; set; }
        public int PatientId { get; set; }
        public int TherapistId { get; set; }
        public int OrganizationId { get; set; }
        public string Subjective { get; set; }
        public string Objective { get; set; }
        public string Assessment { get; set; }
        public string Plans { get; set; }
        public string CreatedDate { get; set; }
    }
    public class DAPNotesDto {
        public int DapNoteId { get; set; }
        public int PatientId { get; set; }
        public int TherapistId { get; set; }
        public int OrganizationId { get; set; }
        public string Data { get; set; }
        public string Assessment { get; set; }
        public string Plans { get; set; }
        public string CreatedDate { get; set; }
    }

    public class PatientSOAPDAP
    {
        public List<SoapNotesDto> soapNotesDtos { get; set; }
        public List<DAPNotesDto> dAPNotesDtos { get; set; }
    }
    public class checkAppointmentDto
    {
        public int appointmentId { get; set; }
        public int userId { get; set; }
    }
}
