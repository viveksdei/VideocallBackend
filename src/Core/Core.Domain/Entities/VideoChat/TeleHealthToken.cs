namespace Core.Domain.Entities.VideoChat
{
    public class TeleHealthToken :BaseAuditableEntity
    {
        public int Id { get; set; }
        public int TeleSessionDetailID { get; set; }

        public string Token { get; set; }
        public double TokenExpiry { get; set; }
        public bool IsStaffToken { get; set; }

        public Exception exception { get; set; }

        public int result { get; set; }

        public virtual TeleSessionDetails TeleSessionDetails { get; set; }
        public int InvitationId { get; set; }
       public int OrganizationId { get; set; }
 
    }
}
