namespace KBeautyApi.Dtos
{
    public record UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Email { get; set; }
        public double? Points { get; set; }
        public double? PointsToNextLevel { get; set; }
        public LevelDto Level { get; set; }
    }
}
