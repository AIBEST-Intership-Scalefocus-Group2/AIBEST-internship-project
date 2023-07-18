using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aibest.Data
{   
    public class Language : ResumeRelatedEntity
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public Levels Level { get; set; }
    }
}
