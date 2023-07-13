using System.ComponentModel.DataAnnotations;

namespace Aibest.Business.Models
{
    public enum Levels
    { 
        A1,
        A2,
        B1, 
        B2,
        C1, 
        C2
    }


    public class LanguageModel : EntityModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Level { get; set; }
    }
}