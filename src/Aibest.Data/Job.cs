using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aibest.Data
{
    public class Job : Entity
    {

        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public DateTime BeginYear { get; set; }
        public DateTime EndYear { get; set; }

        public int ResumeId { get; set; }

        [ForeignKey(nameof(ResumeId))]
        public Resume Resume { get; set; }
    }
}
