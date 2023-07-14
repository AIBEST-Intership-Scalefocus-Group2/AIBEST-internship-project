using Aibest.Business.Models;
using Aibest.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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

        public int AddCertificateToResume(int resumeId, CertificateModel certificate)
        {
            if (!ValidateResume(resumeId))
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
            if (!ValidateResume(resumeId))
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
            return jobNew.Id;
        }

        public int AddLanguageToResume(int resumeId, LanguageModel language)
        {
            if (!ValidateResume(resumeId))
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
            if (!ValidateResume(resumeId))
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
                LastName = resume.LastName,
                FirstName = resume.FirstName,
                UserId = GetCurrentUserId(),
            };
            context.Resumes.Add(resumeNew);
            context.SaveChanges();
            return resumeNew.Id;
        }

        public bool DeleteResume(int resumeId)
        {
            var resume = context.Resumes.FirstOrDefault(r => r.Id == resumeId);
            if (resume == null)
            {
                return false;
            }
            context.Resumes.Remove(resume);
            context.SaveChanges();
            return false;
        }

        public ResumeModel GetResume(int resumeId)
        {
            var resume = context
                .Resumes
                .Where(r => r.Id == resumeId && r.UserId == GetCurrentUserId())
                .Include(x => x.Skills)
                .FirstOrDefault();

            if (resume == null)
            {
                return null;
            }

            var resumeModel = new ResumeModel()
            {
                Id = resumeId,
                Name = resume.Name,
                FirstName = resume.FirstName,
                MiddleName = resume.MiddleName,
                LastName = resume.LastName,
                EmailAddress = resume.EmailAddress,
                PhoneNumber = resume.PhoneNumber,
                Address = resume.Address,
            };

            foreach (var skill in resume.Skills)
            {
                resumeModel.Skills.Add(new SkillModel
                {
                    Id = skill.Id,
                    Name = skill.Name,
                });
            }

            return resumeModel;
        }

        public IEnumerable<ResumeModel> GetResumes()
        {
            var resumes = context.Resumes.Where(r => r.UserId == GetCurrentUserId()).ToList();
            var resumesModel = new List<ResumeModel>();

            foreach (var resume in resumes)
            {
                resumesModel.Add(new ResumeModel()
                {
                    Id = resume.Id,
                    Name = resume.Name,
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

        public bool RemoveResumeRelatedEntity<T>(int id)
            where T : ResumeRelatedEntity
        {
            try
            {
                var entity = context.Set<T>().FirstOrDefault(s => s.Id == id);
                if (entity == null && !IsUserOwnsThat<T>(id))
                {
                    return false;
                }

                context.Set<T>().Remove(entity);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool ValidateResume(int resumeId) =>
            context.Resumes.Any(r => r.Id == resumeId && r.UserId == GetCurrentUserId());

        private string GetCurrentUserId() =>
            this.httpContextAccessor?
                .HttpContext?
                .User?
                .Claims?
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?
                .Value;

        private bool IsUserOwnsThatResume(int resumeId) =>
            this.context.Resumes.Any(r => r.UserId == GetCurrentUserId() && r.Id == resumeId);

        private bool IsUserOwnsThat<T>(int entityId)
             where T : ResumeRelatedEntity =>
            this.context.Set<T>().Any(c => c.Resume.UserId == GetCurrentUserId() && c.Id == entityId);

        private bool ResumeExists(int resumeId) =>
           this.context.Resumes.Any(r => r.Id == resumeId);
    }
}