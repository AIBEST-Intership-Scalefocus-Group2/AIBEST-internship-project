using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aibest.Data
{
    public class Education : Entity
    {

        public string Name { get; set; }
        public string Country { get; set; }
        public string Type { get; set; }
        public string Major { get; set; }
        public DateTime BeginYear { get; set; }
        public DateTime EndYear { get; set; }
        public int ResumeId { get; set; }

        [ForeignKey(nameof(ResumeId))]
        public Resume Resume { get; set; }
    }
}
