namespace FidelityApi.Models
{
    public class Level
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double RequiredPoints { get; set; }
        public string Color1 { get; set; }
        public string Color2 { get; set; }

        public int StoreId { get; set; }
        public Store? Store { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}
