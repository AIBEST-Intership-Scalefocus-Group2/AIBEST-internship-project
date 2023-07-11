using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aibest.Data
{
    public class Certificate : Entity
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public DateTime IssuedYear { get; set; }
        
        public string Description { get; set; }
        
        public int ResumeId { get; set; }

        [ForeignKey(nameof(ResumeId))]
        public Resume Resume { get; set; }
    }
}