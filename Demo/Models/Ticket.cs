﻿namespace Demo.Models
{
    public class Ticket
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Department Department { get; set; }
    }
}