using System;
using System.ComponentModel.DataAnnotations;

namespace Aibest.Business.Models
{
    public class CertificateModel : EntityModel
    {
        [Required]
        public string Name { get; set; }

        public DateTime IssuedYear { get; set; }

        public string Description { get; set; }
    }
}