using System;

namespace Aibest.Application.Models
{
    public class EducationModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Country { get; set; }
        public string Type { get; set; }
        public string Major { get; set; }
        public DateTime BeginYear { get; set; }
        public DateTime EndYear { get; set; }
    }
}
