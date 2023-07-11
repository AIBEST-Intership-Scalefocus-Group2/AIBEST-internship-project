
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aibest.Data
{
    public class Resume : Entity
    {
        public Resume()
        {
            Skills = new HashSet<Skill>();
            Jobs = new HashSet<Job>();
            Educations = new HashSet<Education>();
            Languages = new HashSet<Language>();
            Certificates = new HashSet<Certificate>();
        }

        [Required]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }
        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public ICollection<Skill> Skills { get; }
        public ICollection<Job> Jobs { get; }

        public ICollection<Education> Educations { get; }

        public ICollection<Language> Languages { get; }

        public ICollection<Certificate> Certificates { get; }

        
    }
}
