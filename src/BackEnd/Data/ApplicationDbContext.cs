using App.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<ResumeBaseModel> Resumes { get; set; }
        public DbSet<SkillModel> Skills { get; set; }
        public DbSet<WorkModel> Work { get; set; }
        public DbSet<EducationModel> Education { get; set; }
        public DbSet<LanguageModel> Language { get; set; }
        public DbSet<CertificateModel> Certificates { get; set; }
    }
}