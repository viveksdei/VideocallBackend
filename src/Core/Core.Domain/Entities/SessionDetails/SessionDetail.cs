namespace Core.Domain.Entities.SessionDetails
{
    public class SessionDetail :BaseAuditableEntity
    {
        public int SessionId { get; set; }
        public int SubscriptionPlanId { get; set; }
        public long PaymentID { get; set; }
        public int RemainingSessions { get; set; }
        public DateTime ExpiredOnDate { get; set; }
    }
}
