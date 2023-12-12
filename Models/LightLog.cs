﻿namespace Models
{
    public class LightLog
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime DateSent { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
    }
}