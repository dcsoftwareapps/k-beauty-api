﻿namespace FidelityApi.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<User>? Users { get; set; }
        public ICollection<Level>? Levels { get; set; }
    }
}
