using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aibest.Business.Models
{
    public class ResumeModel : EntityModel
    {
        public ResumeModel()
        {
            Skills = new HashSet<SkillModel>();
            Jobs = new HashSet<JobModel>();
            Educations = new HashSet<EducationModel>();
            Languages = new HashSet<LanguageModel>();
            Certificates = new HashSet<CertificateModel>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public ICollection<SkillModel> Skills { get; }

        public ICollection<JobModel> Jobs { get; }

        public ICollection<EducationModel> Educations { get; }

        public ICollection<LanguageModel> Languages { get; }

        public ICollection<CertificateModel> Certificates { get; }
    }
}