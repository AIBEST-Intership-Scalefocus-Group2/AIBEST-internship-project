using Aibest.Business.Models;
using Aibest.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Aibest.Business.Services
{
    public class ResumeService : IResumeService
    {
        private readonly ApplicationDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ResumeService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor = null)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }

        public bool IsUserOwnsThatResume(int resumeId) =>
            this.context.Resumes.Any(r => r.UserId == GetCurrentUserId() && r.Id == resumeId);

        public bool IsUserOwnsThat<T>(int entityId)
             where T : ResumeRelatedEntity =>
            this.context.Set<T>().Any(c => c.Resume.UserId == GetCurrentUserId() && c.Id == entityId);

        private bool ResumeExists(int resumeId) =>
           this.context.Resumes.Any(r => r.Id == resumeId);

        public int AddCertificateToResume(int resumeId, CertificateModel certificate)
        {
            if (!ResumeExists(resumeId) && IsUserOwnsThatResume(resumeId))
            {
                return -1;
            }

            var certificateNew = new Certificate()
            {
                ResumeId = resumeId,
                Name = certificate.Name,
                IssuedYear = certificate.IssuedYear,
                Description = certificate.Description,
            };
            context.Certificates.Add(certificateNew);
            context.SaveChanges();
            return resumeId;
        }

        public int AddEducationToResume(int resumeId, EducationModel education)
        {
            if (!ResumeExists(resumeId) && IsUserOwnsThatResume(resumeId))
            {
                return -1;
            }
            var educationNew = new Education()
            {
                ResumeId = resumeId,
                Name = education.Name,
                BeginYear = education.BeginYear,
                EndYear = education.EndYear,
                Country = education.Country,
                Major = education.Major,
            };

            context.Educations.Add(educationNew);
            context.SaveChanges();
            return resumeId;
        }

        public int AddJobToResume(int resumeId, JobModel job)
        {
            if (!ResumeExists(resumeId) && IsUserOwnsThatResume(resumeId))
            {
                return -1;
            }
            var jobNew = new Job()
            {
                ResumeId = resumeId,
                Name = job.Name,
                BeginYear = job.BeginYear,
                EndYear = job.EndYear,
                CompanyName = job.CompanyName,
                Description = job.Description,
                Position = job.Position,
            };

            context.Jobs.Add(jobNew);
            context.SaveChanges();
            return resumeId;
        }

        public int AddLanguageToResume(int resumeId, LanguageModel language)
        {
            if (!ResumeExists(resumeId) && IsUserOwnsThatResume(resumeId))
            {
                return -1;
            }

            bool levelExists = Enum.TryParse(language.Level, true, out Levels result);
            if (!levelExists)
            {
                return -1;
            }
            var languageNew = new Language()
            {
                ResumeId = resumeId,
                Name = language.Name,
                Level = language.Level,
            };
            //Levels.Parse(language.Level)
            context.Languages.Add(languageNew);
            context.SaveChanges();
            return resumeId;
        }

        public int AddSkillToResume(int resumeId, SkillModel skill)
        {
            if (!ResumeExists(resumeId) && IsUserOwnsThatResume(resumeId))
            {
                return -1;
            }
            var skillNew = new Skill()
            {
                ResumeId = resumeId,
                Name = skill.Name
            };
            context.Skills.Add(skillNew);
            context.SaveChanges();
            return resumeId;
        }

        public int CreateResume(ResumeModel resume)
        {
            var resumeNew = new Resume()
            {
                Name = resume.Name,
                UserId = resume.UserId
            };
            context.Resumes.Add(resumeNew);
            context.SaveChanges();
            return resume.Id;
        }

        public int DeleteResume(int resumeId)
        {
            if (!ResumeExists(resumeId))
            {
                return -1;
            }
            var resume = context.Resumes.FirstOrDefault(r => r.Id == resumeId);
            if (resume == null)
            {
                return -1;
            }
            context.Resumes.Remove(resume);
            context.SaveChanges();
            return resumeId;
        }

        public List<CertificateModel> GetCertificatesByResumeId(int resumeId)
        {
            if (!ResumeExists(resumeId))
            {
                return new List<CertificateModel>();
            }
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
            if (!ResumeExists(resumeId))
            {
                return new List<EducationModel>();
            }
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
            if (!ResumeExists(resumeId))
            {
                return new List<JobModel>();
            }
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
            if (!ResumeExists(resumeId))
            {
                return new List<LanguageModel>();
            }
            var languages = context.Languages.Where(c => c.ResumeId == resumeId).ToList();
            ;
            var languagesModel = new List<LanguageModel>();

            foreach (var language in languages)
            {
                languagesModel.Add(new LanguageModel()
                {
                    Name = language.Name,
                    Level = language.Level,
                });
            }

            return languagesModel;
        }

        public ResumeModel GetResumeById(int resumeId)
        {
            if (!ResumeExists(resumeId))
            {
                return new ResumeModel();
            }
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
                Address = resumes.Name,
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
            if (!ResumeExists(resumeId))
            {
                return new List<SkillModel>();
            }
            var skills = context.Skills.Where(c => c.ResumeId == resumeId).ToList();
            var skillsModel = new List<SkillModel>();

            foreach (var skill in skills)
            {
                skillsModel.Add(new SkillModel()
                {
                    Name = skill.Name,
                });
            }

            return skillsModel;
        }

        public int RemoveCertificate(int certificateId)
        {
            var certificate = context.Certificates.FirstOrDefault(c => c.Id == certificateId);
            if (certificate == null && !IsUserOwnsThat<Certificate>(certificateId))
            {
                return -1;
            }

            context.Certificates.Remove(certificate);
            context.SaveChanges();
            return certificateId;
        }

        public int RemoveEducation(int educationId)
        {
            var education = context.Educations.FirstOrDefault(e => e.Id == educationId);
            if (education == null && !IsUserOwnsThat<Education>(educationId))
            {
                return -1;
            }

            context.Educations.Remove(education);
            context.SaveChanges();
            return educationId;
        }

        public int RemoveJob(int jobId)
        {
            var job = context.Jobs.FirstOrDefault(j => j.Id == jobId);
            if (job == null && !IsUserOwnsThat<Job>(jobId))
            {
                return -1;
            }

            context.Jobs.Remove(job);
            context.SaveChanges();
            return jobId;

        }

        public int RemoveLanguage(int languageId)
        {
            var language = context.Languages.FirstOrDefault(l => l.Id == languageId);
            if (language == null && !IsUserOwnsThat<Language>(languageId))
            {
                return -1;
            }

            context.Languages.Remove(language);
            context.SaveChanges();
            return languageId;
        }

        public int RemoveSkill(int skillId)
        {
            var skill = context.Skills.FirstOrDefault(s => s.Id == skillId);
            if (skill == null && !IsUserOwnsThat<Skill>(skillId))
            {
                return -1;
            }

            context.Skills.Remove(skill);
            context.SaveChanges();
            return skillId;
        }

        public int UpdateResume(ResumeModel resumeModel)
        {
            var resume = context.Resumes.FirstOrDefault(r => r.Id == resumeModel.Id);
            if (resume == null && !IsUserOwnsThatResume(resumeModel.Id))
            {
                return -1;
            }
            resume.FirstName = resumeModel.FirstName;
            resume.MiddleName = resumeModel.MiddleName;
            resume.LastName = resumeModel.LastName;
            resume.EmailAddress = resumeModel.EmailAddress;
            resume.PhoneNumber = resumeModel.PhoneNumber;
            resume.Address = resumeModel.Address;
            context.SaveChanges();
            return resumeModel.Id;
        }
        //TODO: return id when adding
        //TODO: IEnumerable lang level

        private string GetCurrentUserId()
        {
            return this.httpContextAccessor?
                .HttpContext?
                .User?
                .Claims?
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?
                .Value;
        }
    }
}