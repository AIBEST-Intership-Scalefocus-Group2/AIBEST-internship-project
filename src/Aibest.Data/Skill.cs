using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aibest.Data
{
    public class Skill : ResumeRelatedEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
