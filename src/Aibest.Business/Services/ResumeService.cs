using Aibest.Business.Models;
using Aibest.Data;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

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
            return true;
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
            return true;
        }

        public bool AddLanguageToResume(ResumeModel resume, LanguageModel language)
        {
            var languageNew = new Language()
            {
                Name = language.Name,
                Level = language.Level,
            };
            context.Languages.Add(languageNew);
            context.SaveChanges();
            return true;
        }

        public bool AddSkillToResume(ResumeModel resume, SkillModel skill)
        {
            var skillNew = new Skill()
            {
                Name = skill.Name
            };
            context.Skills.Add(skillNew);
            context.SaveChanges();
            return true;
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
            return true;
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
            return false;
        }

        public List<CertificateModel> GetCertificatesByResumeId(int resumeId)
        {
            var certificates = context.Certificates.Where(c => c.ResumeId == resumeId).ToList();
            var certificatesModel = new List<CertificateModel>();

            foreach (var certificate in certificates)
            {
                certificatesModel.Add(new CertificateModel()
                {
                    Name = certificate.Name,
                    IssuedYear = certificate.IssuedYear,
                    Description = certificate.Description,
                });
            }

            return certificatesModel;
        }

        public List<EducationModel> GetEducationsByResumeId(int resumeId)
        {
            var educations = context.Educations.Where(c => c.ResumeId == resumeId).ToList();
            var educationsModel = new List<EducationModel>();

            foreach (var education in educations)
            {
                educationsModel.Add(new EducationModel()
                {
                    Name = education.Name,
                    BeginYear = education.BeginYear,
                    EndYear = education.EndYear,
                    Country = education.Country,
                    Major = education.Major,
                });
            }

            return educationsModel;
        }

        public List<JobModel> GetJobsByResumeId(int resumeId)
        {
            var jobs = context.Jobs.Where(c => c.ResumeId == resumeId).ToList();
            var jobsModel = new List<JobModel>();

            foreach (var job in jobs)
            {
                jobsModel.Add(new JobModel()
                {
                    Name = job.Name,
                    BeginYear = job.BeginYear,
                    EndYear = job.EndYear,
                    CompanyName = job.CompanyName,
                    Description = job.Description,
                    Position = job.Position
                });
            }

            return jobsModel;
        }

        public List<LanguageModel> GetLanguagesByResumeId(int resumeId)
        {
            var languages = context.Languages.Where(c => c.ResumeId == resumeId).ToList();
            ;
            var languagesModel = new List<LanguageModel>();

            foreach (var language in languages)
            {
                languagesModel.Add(new LanguageModel()
                {
                    Name = language.Name,
                    Level = language.Level
                });
            }

            return languagesModel;
        }

        public ResumeModel GetResumeById(int resumeId)
        {
            var resumes = context.Resumes.FirstOrDefault(r => r.Id == resumeId);
            var resumeModel = new ResumeModel()
            {
                Id = resumeId,
                Name = resumes.Name,
                UserId = resumes.Name,
                FirstName = resumes.Name,
                MiddleName = resumes.Name,
                LastName = resumes.Name,
                EmailAddress = resumes.Name,
                PhoneNumber = resumes.Name,
                Address = resumes.Name
            };
            return resumeModel;
        }

        public List<ResumeModel> GetResumesByUserId(string userId)
        {
            var resumes = context.Resumes.Where(r => r.UserId == userId).ToList();
            var resumesModel = new List<ResumeModel>();

            foreach (var resume in resumes)
            {
                resumesModel.Add(new ResumeModel()
                {
                    Id = resume.Id,
                    Name = resume.Name,
                    UserId = userId,
                    FirstName = resume.FirstName,
                    MiddleName = resume.MiddleName,
                    LastName = resume.LastName,
                    EmailAddress = resume.EmailAddress,
                    PhoneNumber = resume.PhoneNumber,
                    Address = resume.Address
                });
            }

            return resumesModel;
        }

        public List<SkillModel> GetSkillsByResumeId(int resumeId)
        {
            var skills = context.Skills.Where(c => c.ResumeId == resumeId).ToList();
            var skillsModel = new List<SkillModel>();

            foreach (var certificate in skills)
            {
                skillsModel.Add(new SkillModel()
                {

                });
            }

            return skillsModel;
        }

        public bool RemoveCertificate(int certificateId)
        {
            var certificate = context.Certificates.FirstOrDefault(c => c.Id == certificateId);
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
            var education = context.Educations.FirstOrDefault(e => e.Id == educationId);
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
            var job = context.Jobs.FirstOrDefault(j => j.Id == jobId);
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
            var language = context.Languages.FirstOrDefault(l => l.Id == languageId);
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
            var skill = context.Skills.FirstOrDefault(s => s.Id == skillId);
            if (skill != null)
            {
                context.Skills.Remove(skill);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateResume(ResumeModel resumeModel)
        {
            var resume = new Resume();
            if (resume != null)
            {
                resume.FirstName = resumeModel.FirstName;
                resume.MiddleName = resumeModel.MiddleName;
                resume.LastName = resumeModel.LastName;
                resume.EmailAddress = resumeModel.EmailAddress;
                resume.PhoneNumber = resumeModel.PhoneNumber;
                resume.Address = resumeModel.Address;
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}