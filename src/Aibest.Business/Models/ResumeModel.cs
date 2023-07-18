using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aibest.Business.Models
{
    public class ResumeModel : EntityModel
    {
        public ResumeModel()
        {
            Skills = new List<SkillModel>();
            Jobs = new List<JobModel>();
            Educations = new List<EducationModel>();
            Languages = new List<LanguageModel>();
            Certificates = new List<CertificateModel>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public IList<SkillModel> Skills { get; }

        public IList<JobModel> Jobs { get; }

        public IList<EducationModel> Educations { get; }

        public IList<LanguageModel> Languages { get; }

        public IList<CertificateModel> Certificates { get; }
    }
}