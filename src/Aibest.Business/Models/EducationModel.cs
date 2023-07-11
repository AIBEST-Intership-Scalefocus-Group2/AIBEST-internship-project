using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aibest.Business.Models
{
    public class EducationModel : EntityModel
    {
        public string Name { get; set; }

        public string Country { get; set; }

        //public string Type { get; set; }

        public string Major { get; set; }

        public DateTime BeginYear { get; set; }

        public DateTime EndYear { get; set; }

        public int ResumeId { get; set; }
    }
}
