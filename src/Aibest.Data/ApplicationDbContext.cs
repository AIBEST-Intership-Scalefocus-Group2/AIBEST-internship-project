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

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
    }
}