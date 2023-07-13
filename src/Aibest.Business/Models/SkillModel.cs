using System.ComponentModel.DataAnnotations;

namespace Aibest.Business.Models
{
    public class SkillModel : EntityModel
    {
        [Required]
        public string Name { get; set; }
    }
}