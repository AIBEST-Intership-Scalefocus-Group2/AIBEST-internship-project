using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aibest.Data
{
    public class Certificate : Entity
    {
        public string Name { get; set; }
        public DateTime IssuedYear { get; set; }
        public string Description { get; set; }

        public int ResumeId { get; set; }

        [ForeignKey(nameof(ResumeId))]
        public Resume Resume { get; set; }
    }
}
