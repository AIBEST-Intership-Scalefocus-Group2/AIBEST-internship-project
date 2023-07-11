using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aibest.Business.Models
{
    public class CertificateModel : EntityModel
    {
        public string Name { get; set; }

        public DateTime IssuedYear { get; set; }

        public string Description { get; set; }

        public int ResumeId { get; set; }
    }
}
