using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aibest.Data
{
    public class Certificate : ResumeRelatedEntity
    {
        [Required]
        public string Name { get; set; }

        public DateTime IssuedYear { get; set; }

        public string Description { get; set; }
    }
}