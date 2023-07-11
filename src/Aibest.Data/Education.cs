using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aibest.Data
{
    public class Education : Entity
    {
        [Required]
        public string Name { get; set; }
        public string Country { get; set; }

        //public string Type { get; set; }
        
        [Required]
        public string Major { get; set; }
        
        [Required]
        public DateTime BeginYear { get; set; }
        
        [Required]
        public DateTime EndYear { get; set; }
        
        public int ResumeId { get; set; }

        [ForeignKey(nameof(ResumeId))]
        public Resume Resume { get; set; }
    }
}
