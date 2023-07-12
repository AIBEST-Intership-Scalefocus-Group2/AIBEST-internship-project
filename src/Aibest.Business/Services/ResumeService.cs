using Aibest.Business.Models;
using Aibest.Data;
using System;
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

        public bool AddCertificateToResume(int resumeId, string name, DateTime issuedYear, string description)
        {
            var certificate = new CertificateModel()
            {
                ResumeId = resumeId,
                Name = name,
                IssuedYear = issuedYear,
                Description = description
            };
            context.Certificates.Add(certificate);
            context.SaveChanges();
        }

        public bool AddEducationToResume(int resumeId, string name, string country, string major, DateTime beginYear, DateTime endYear)
        {
            var education = new EducationModel()
            {
                ResumeId = resumeId,
                Name = name,
                Country = country,
                Major = major,
                BeginYear = beginYear,
                EndYear = endYear
            };
            context.Educations.Add(education);
            context.SaveChanges();
        }

        public bool AddJobToResume(string name, int resumeId, string companyName, string position, string description, DateTime beginYear, DateTime endYear)
        {
            var job = new JobModel()
            {
                ResumeId = resumeId,
                Name = name,
                CompanyName = companyName,
                Position = position,
                Description = description,
                BeginYear = beginYear,
                EndYear = endYear
            };
            context.Jobs.Add(job);
            context.SaveChanges();
        }

        public bool AddLanguageToResume(int resumeId, string name, string level)
        {
            var language = new LanguageModel()
            {
                ResumeId = resumeId,
                Name = name,
                Level = level
            };
            context.Languages.Add(language);
            context.SaveChanges();
        }

        public bool AddSkillToResume(int resumeId, string name)
        {
            var skill = new SkillModel()
            {
                ResumeId = resumeId,
                Name = name
            };
            context.Skills.Add(skill);
            context.SaveChanges();
        }

        public bool CreateResume(string resumeName, int userId)
        {
            var resume = new ResumeModel()
            {
                Name = resumeName,
                UserId = userId
            };
            context.Resumes.Add(resume);
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
            return context.Certificates.Where(c => c.ResumeId == resumeId).ToList();
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

        public bool RemoveCertificate(int resumeId, int certificateId)
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

        public bool RemoveEducation(int resumeId, int educationId)
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

        public bool RemoveJob(int resumeId, int jobId)
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

        public bool RemoveLanguage(int resumeId, int languageId)
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

        public bool RemoveSkillFromResume(int resumeId, int skillId)
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

        public bool UpdateResume(string FirstName, string MiddleName, string LastName, string Email, string PhoneNumber, string Address)
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