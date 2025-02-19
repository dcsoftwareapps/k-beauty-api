namespace FidelityApi.Dtos
{
    public record LevelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double RequiredPoints { get; set; }
        public string Color1 { get; set; }
        public string Color2 { get; set; }
    }
}
