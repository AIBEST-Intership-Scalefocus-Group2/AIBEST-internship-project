using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aibest.Data
{
    public class Education : ResumeRelatedEntity
    {
        [Required]
        public string Name { get; set; }
        public string Country { get; set; }

        //public string Type { get; set; }
        
        [Required]
        public string Major { get; set; }
        
        public DateTime BeginYear { get; set; }
        
        public DateTime EndYear { get; set; }
    }
}
