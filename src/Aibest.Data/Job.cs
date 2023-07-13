using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aibest.Data
{
    public class Job : ResumeRelatedEntity
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string CompanyName { get; set; }
        
        [Required]
        public string Position { get; set; }
        
        public string Description { get; set; }
        
        public DateTime BeginYear { get; set; }
        
        public DateTime EndYear { get; set; }
    }
}
