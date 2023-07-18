using Aibest.Data;
using System.ComponentModel.DataAnnotations;

namespace Aibest.Business.Models
{
    public class LanguageModel : EntityModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Levels Level { get; set; }
    }
}