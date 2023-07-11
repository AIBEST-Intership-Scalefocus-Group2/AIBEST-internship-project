using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aibest.Data
{
    public class Job : Entity
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string CompanyName { get; set; }
        
        [Required]
        public string Position { get; set; }
        
        public string Description { get; set; }
        
        [Required]
        public DateTime BeginYear { get; set; }
        
        [Required]
        public DateTime EndYear { get; set; }

        public int ResumeId { get; set; }

        [ForeignKey(nameof(ResumeId))]
        public Resume Resume { get; set; }
    }
}
