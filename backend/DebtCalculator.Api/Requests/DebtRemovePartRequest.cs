namespace DebtCalculator.Api.Requests
{
    public class DebtRemovePartRequest
    {
        public int UserId { get; set; }
        public int DebtId { get; set; }
        public decimal Amount { get; set; }
    }
}
