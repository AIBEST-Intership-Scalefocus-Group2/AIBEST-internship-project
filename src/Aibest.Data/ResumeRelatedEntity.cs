using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aibest.Data
{
    public abstract class ResumeRelatedEntity : Entity
    {
        public int ResumeId { get; set; }

        [ForeignKey(nameof(ResumeId))]
        public Resume Resume { get; set; }
    }
}
