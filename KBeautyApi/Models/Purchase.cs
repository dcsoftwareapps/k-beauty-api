namespace FidelityApi.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }

        public int UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
