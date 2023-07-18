using Aibest.Business.Models;
using Aibest.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<ResumeService> _logger;

        public ResumeService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor = null,ILogger<ResumeService> logger = null)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
            this._logger = logger;
        }

        public bool AddCertificateToResume(int resumeId, CertificateModel certificate)
        {
            if (!ValidateResume(resumeId))
            {
                return false;
            }

            try
            {
                var certificateNew = new Certificate()
                {
                    ResumeId = resumeId,
                    Name = certificate.Name,
                    IssuedYear = certificate.IssuedYear,
                    Description = certificate.Description,
                };
                context.Certificates.Add(certificateNew);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                _logger.LogError("Incorrect data");
                return false;
            }
        }

        public bool AddEducationToResume(int resumeId, EducationModel education)
        {
            if (!ValidateResume(resumeId))
            {
                return false;
            }

            try
            {
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
                return true;
            }
            catch (Exception)
            {
                _logger.LogError("");
                return false;
            }
        }

        public bool AddJobToResume(int resumeId, JobModel job)
        {
            if (!ResumeExists(resumeId) && IsUserOwnsThatResume(resumeId))
            {
                return false;
            }
            try
            {
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
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddLanguageToResume(int resumeId, LanguageModel language)
        {
            if (!ValidateResume(resumeId))
            {
                return false;
            }

            try
            {
                bool levelExists = Enum.TryParse<Levels>(language.Name, out var level);
                if (!levelExists)
                {
                    return false;
                }
                var languageNew = new Language()
                {
                    ResumeId = resumeId,
                    Name = language.Name,
                    Level = language.Level,
                };

                context.Languages.Add(languageNew);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddSkillToResume(int resumeId, SkillModel skill)
        {
            if (!ValidateResume(resumeId))
            {
                return false;
            }

            try
            {
                var skillNew = new Skill()
                {
                    ResumeId = resumeId,
                    Name = skill.Name
                };
                context.Skills.Add(skillNew);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CreateResume(ResumeModel resume)
        {
            try
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
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteResume(int resumeId)
        {
            try
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
            catch (Exception)
            {
                return false;
            }
        }

        public ResumeModel GetResume(int resumeId)
        {
            var resume = context
                .Resumes
                .Where(r => r.Id == resumeId && r.UserId == GetCurrentUserId())
                .Include(x => x.Certificates)
                .Include(x => x.Skills)
                .Include(x => x.Educations)
                .Include(x => x.Jobs)
                .Include(x => x.Languages)
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
                Description = resume.Description
            };

            foreach (var skill in resume.Skills)
            {
                resumeModel.Skills.Add(new SkillModel
                {
                    Id = skill.Id,
                    Name = skill.Name,
                });
            }

            foreach (var job in resume.Jobs)
            {
                resumeModel.Jobs.Add(new JobModel
                {
                    Id = job.Id,
                    Name = job.Name,
                    CompanyName = job.CompanyName,
                    Position = job.Position,
                    Description = job.Description,
                    BeginYear = job.BeginYear,
                    EndYear = job.EndYear
                });
            }

            foreach (var education in resume.Educations)
            {
                resumeModel.Educations.Add(new EducationModel
                {
                    Id = education.Id,
                    Name = education.Name,
                    Country = education.Country,
                    Major = education.Major,
                    BeginYear = education.BeginYear,
                    EndYear = education.EndYear
                });
            }

            foreach (var language in resume.Languages)
            {
                resumeModel.Languages.Add(new LanguageModel
                {
                    Id = language.Id,
                    Name = language.Name,
                    Level = language.Level
                });
            }

            foreach (var certificate in resume.Certificates)
            {
                resumeModel.Certificates.Add(new CertificateModel
                {
                    Id = certificate.Id,
                    Name = certificate.Name,
                    IssuedYear = certificate.IssuedYear,
                    Description = certificate.Description
                });
            }

            return resumeModel;
        }

        public IEnumerable<ResumeModel> GetResumes()
        {
            var resumes = context
                          .Resumes
                          .Where(r => r.UserId == GetCurrentUserId());

            if(resumes == null)
            {
                return null;
            }

            var resumesModel = new List<ResumeModel>();

            foreach (var resume in resumes)
            {
                resumesModel.Add(GetResume(resume.Id));
            }

            return resumesModel;
        }

        public bool UpdateResume(ResumeModel resumeModel)
        {
            try
            {
                var resume = context.Resumes.FirstOrDefault(r => r.Id == resumeModel.Id);
                if (resume == null && !IsUserOwnsThatResume(resumeModel.Id))
                {
                    return false;
                }
                resume.FirstName = resumeModel.FirstName;
                resume.MiddleName = resumeModel.MiddleName;
                resume.LastName = resumeModel.LastName;
                resume.EmailAddress = resumeModel.EmailAddress;
                resume.PhoneNumber = resumeModel.PhoneNumber;
                resume.Address = resumeModel.Address;
                resume.Description = resumeModel.Description;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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