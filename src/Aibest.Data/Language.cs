using System.ComponentModel.DataAnnotations.Schema;

namespace Aibest.Data
{
    public class Language : Entity
    {
        public string LanguageName { get; set; }
        public string Level { get; set; }
        public int ResumeId { get; set; }

        [ForeignKey(nameof(ResumeId))]
        public Resume Resume { get; set; }
    }
}
