﻿using SQLite;
namespace Finansik.Service.DTO
{
    public class Finanse
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } 
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public float Price { get; set; }
    }
}
