using Aibest.Business.Models;
using Aibest.Data;
using System.Collections.Generic;
using System.Linq;

namespace Aibest.Business.Services
{
    public class ResumeService : IResumeService
    {
        private readonly ApplicationDbContext context;

        public ResumeService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool AddCertificateToResume(ResumeModel resume, CertificateModel certificate)
        {
            var certificateNew = new Certificate()
            {
                Name = certificate.Name,
                IssuedYear = certificate.IssuedYear,
                Description = certificate.Description,
            };
            context.Certificates.Add(certificateNew);
            context.SaveChanges();
            return true;
        }

        public bool AddEducationToResume(ResumeModel resume, EducationModel education)
        {
            var educationNew = new Education()
            {
                Name = education.Name,
                BeginYear = education.BeginYear,
                EndYear = education.EndYear,
                Country = education.Country,
                Major = education.Major,
                

            };
            context.Educations.Add(educationNew);
            context.SaveChanges();
        }

        public bool AddJobToResume(ResumeModel resume, JobModel job)
        {
            var jobNew = new Job()
            {
                Name = job.Name,
                BeginYear = job.BeginYear,  
                EndYear = job.EndYear,
                CompanyName = job.CompanyName,
                Description = job.Description,
                Position = job.Position,
                
            };
            context.Jobs.Add(jobNew);
            context.SaveChanges();
        }

        public bool AddLanguageToResume(ResumeModel resume, LanguageModel language)
        {
            var languageNew = new LanguageModel()
            {
                Name = language.Name,
                Level = language.Level,
                
                            };
            context.Languages.Add(languageNew);
            context.SaveChanges();
        }

        public bool AddSkillToResume(ResumeModel resume, SkillModel skill)
        {
            var skillNew = new Skill()
            {
                
                Name = skill.Name
            };
            context.Skills.Add(skillNew);
            context.SaveChanges();
        }

        public bool CreateResume(ResumeModel resume)
        {
            var resumeNew = new Resume()
            {
                Name = resume.Name,
                UserId = resume.UserId
            };
            context.Resumes.Add(resumeNew);
            context.SaveChanges();
        }

        public bool DeleteResume(int resumeId)
        {
            var resume = context.Resumes.FirstOrDefault(r => r.Id == resumeId);
            if (resume != null)
            {
                context.Resumes.Remove(resume);
                context.SaveChanges();
                return true;
            }
        }

        public List<CertificateModel> GetCertificatesByResumeId(int resumeId)
        {
            var certificates = context.Certificates.Where(c => c.ResumeId == resumeId).ToList();

        }

        public List<EducationModel> GetEducationsByResumeId(int resumeId)
        {
            return context.Educations.Where(c => c.ResumeId == resumeId).ToList();
        }

        public List<JobModel> GetJobsByResumeId(int resumeId)
        {
            return context.Jobs.Where(c => c.ResumeId == resumeId).ToList();
        }

        public List<LanguageModel> GetLanguagesByResumeId(int resumeId)
        {
            return context.Languages.Where(c => c.ResumeId == resumeId).ToList();
        }

        public bool GetResumeById(int resumeId)
        {
            var resume = context.Resumes.FirstOrDefault(r => r.Id == resumeId);
        }

        public List<ResumeModel> GetResumesByUserId(int userId)
        {
            var resumes = context.Resumes.Where(r => r.UserId == userId).ToList();
        }

        public List<SkillModel> GetSkillsByResumeId(int resumeId)
        {
            return context.Skills.Where(c => c.ResumeId == resumeId).ToList();
        }

        public bool RemoveCertificate(int certificateId)
        {
            var certificate = context.Certificates.FirstOrDefault(c => c.Id == certificateId && c.ResumeId == resumeId);
            if (certificate != null)
            {
                context.Certificates.Remove(certificate);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool RemoveEducation(int educationId)
        {
            var education = context.Educations.FirstOrDefault(e => e.Id == educationId && e.ResumeId == resumeId);
            if (education != null)
            {
                context.Educations.Remove(education);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool RemoveJob(int jobId)
        {
            var job = context.Jobs.FirstOrDefault(j => j.Id == jobId && j.ResumeId == resumeId);
            if (job != null)
            {
                context.Jobs.Remove(job);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool RemoveLanguage(int languageId)
        {
            var language = context.Languages.FirstOrDefault(l => l.Id == languageId && l.ResumeId == resumeId);
            if (language != null)
            {
                context.Languages.Remove(language);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool RemoveSkillFromResume(int skillId)
        {
            var skill = context.Skills.FirstOrDefault(s => s.Id == skillId && s.ResumeId == resumeId);
            if (skill != null)
            {
                context.Skills.Remove(skill);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateResume(ResumeModel resume)
        {
            var resume = context.Resumes.FirstOrDefault(r => r.Id == resumeId);
            if (resume != null)
            {
                resume.FirstName = FirstName;
                resume.MiddleName = MiddleName;
                resume.LastName = LastName;
                resume.Email = Email;
                resume.PhoneNumber = PhoneNumber;
                resume.Address = Address;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        ResumeModel IResumeService.GetResumeById(int resumeId)
        {
            return context.Resumes.Where(c => c.Id == resumeId).FirstOrDefault();
        }
    }
}