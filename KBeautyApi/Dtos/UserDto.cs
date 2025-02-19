namespace FidelityApi.Dtos
{
    public record UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double? Points { get; set; }
        public double? PointsToNextLevel { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int StoreId { get; set; }
        public LevelDto Level { get; set; }
    }
}
