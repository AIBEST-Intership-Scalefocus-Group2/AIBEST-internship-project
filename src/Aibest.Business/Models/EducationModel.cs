using System;
using System.ComponentModel.DataAnnotations;

namespace Aibest.Business.Models
{
    public class EducationModel : EntityModel
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