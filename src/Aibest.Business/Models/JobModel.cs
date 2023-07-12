using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aibest.Business.Models
{
    public class JobModel : EntityModel
    {
        public string Name { get; set; }

        public string CompanyName { get; set; }

        public string Position { get; set; }

        public string Description { get; set; }

        public DateTime BeginYear { get; set; }

        public DateTime EndYear { get; set; }
    }
}
