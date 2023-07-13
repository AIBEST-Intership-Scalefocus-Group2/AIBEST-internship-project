using Aibest.Business.Models;
using System.Collections.Generic;

namespace Aibest.Business.Services
{
    public interface IResumeService
    {
        int CreateResume(ResumeModel resume);

        int UpdateResume(ResumeModel resume);

        int DeleteResume(int resumeId);

        ResumeModel GetResumeById(int resumeId);

        int AddSkillToResume(int resumeId, SkillModel skill);

        int RemoveSkill(int skillId);

        int AddJobToResume(int resumeId, JobModel job);

        int RemoveJob(int jobId);

        int AddEducationToResume(int resumeId, EducationModel education);

        int RemoveEducation(int educationId);

        int AddLanguageToResume(int resumeId, LanguageModel language);

        int RemoveLanguage(int languageId);

        int AddCertificateToResume(int resumeId, CertificateModel certificate);

        int RemoveCertificate(int certificateId);

        List<ResumeModel> GetResumesByUserId(string userId);

        List<CertificateModel> GetCertificatesByResumeId(int resumeId);

        List<JobModel> GetJobsByResumeId(int resumeId);

        List<LanguageModel> GetLanguagesByResumeId(int resumeId);

        List<SkillModel> GetSkillsByResumeId(int resumeId);

        List<EducationModel> GetEducationsByResumeId(int resumeId);
    }
}