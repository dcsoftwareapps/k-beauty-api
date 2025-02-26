namespace KBeautyApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }
        public double? Points { get; set; }
        public double? PointsToNextLevel { get; set; }

        public int StoreId { get; set; }
        public Store? Store { get; set; }

        public int LevelId { get; set; }
        public Level? Level { get; set; }

        public ICollection<Purchase>? Purchases { get; set; }
    }
}
