using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Aibest.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Resume> Resumes { get; set; }

        public DbSet<Skill> Skills { get; set; }

        //public DbSet<WorkModel> Work { get; set; }
        //public DbSet<EducationModel> Education { get; set; }
        //public DbSet<LanguageModel> Language { get; set; }
        //public DbSet<CertificateModel> Certificates { get; set; }
    }
}