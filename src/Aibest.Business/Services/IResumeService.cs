using Aibest.Business.Models;
using System.Collections.Generic;

namespace Aibest.Business.Services
{
    public interface IResumeService
    {
        bool CreateResume(ResumeModel resume);

        bool UpdateResume(ResumeModel resume);

        bool DeleteResume(int resumeId);

        ResumeModel GetResumeById(int resumeId);

        bool AddSkillToResume(int resumeId, SkillModel skill);

        bool RemoveSkill(int skillId);

        bool AddJobToResume(int resumeId, JobModel job);

        bool RemoveJob(int jobId);

        bool AddEducationToResume(int resumeId, EducationModel education);

        bool RemoveEducation(int educationId);

        bool AddLanguageToResume(int resumeId, LanguageModel language);

        bool RemoveLanguage(int languageId);

        bool AddCertificateToResume(int resumeId, CertificateModel certificate);

        bool RemoveCertificate(int certificateId);

        List<ResumeModel> GetResumesByUserId(string userId);

        List<CertificateModel> GetCertificatesByResumeId(int resumeId);

        List<JobModel> GetJobsByResumeId(int resumeId);

        List<LanguageModel> GetLanguagesByResumeId(int resumeId);

        List<SkillModel> GetSkillsByResumeId(int resumeId);

        List<EducationModel> GetEducationsByResumeId(int resumeId);
    }
}