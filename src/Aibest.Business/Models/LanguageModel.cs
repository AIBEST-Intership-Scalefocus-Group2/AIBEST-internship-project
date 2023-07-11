using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aibest.Business.Models
{
    public class LanguageModel : EntityModel
    {
        public string LanguageName { get; set; }

        public string Level { get; set; }

        public int ResumeId { get; set; }
    }
}
