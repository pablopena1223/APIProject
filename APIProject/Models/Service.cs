using System;
namespace APIProject.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string? ServiceName { get; set; }
        public double? Price { get; set; }
        public string? Policy { get; set; }
        public string? ServiceType { get; set; }
        public int CompanyId { get; set; }
        public int? StudentId { get; set; }
    }
}

