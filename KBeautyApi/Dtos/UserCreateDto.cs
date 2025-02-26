namespace KBeautyApi.Dtos
{
    public record UserCreateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string StoreCode { get; set; }
    }
}
