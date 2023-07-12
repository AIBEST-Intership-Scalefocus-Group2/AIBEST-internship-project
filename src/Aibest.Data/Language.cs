using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aibest.Data
{
    public class Language : Entity
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Level { get; set; }
        
        public int ResumeId { get; set; }

        [ForeignKey(nameof(ResumeId))]
        public Resume Resume { get; set; }
    }
}
