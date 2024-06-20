namespace Api.DTO.PatientSlot
{
    public class PatientSlotDto
    {
        public int SlotId { get; set; }
        public int PatientId { get; set; }
        public int TherapistId { get; set; }
        public DateTime SlotDate { get; set; }
        public int SlotTimeId { get; set; }
        public string CreatedBy { get; set; }
    }
}


