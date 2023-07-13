using System;
using System.ComponentModel.DataAnnotations;

namespace Aibest.Business.Models
{
    public class JobModel : EntityModel
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