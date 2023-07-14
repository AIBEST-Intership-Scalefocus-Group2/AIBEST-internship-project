using Aibest.Business.Models;
using Aibest.Data;
using System.Collections.Generic;

namespace Aibest.Business.Services
{
    public interface IResumeService
    {
        IEnumerable<ResumeModel> GetResumes();

        ResumeModel GetResume(int resumeId);

        int CreateResume(ResumeModel resume);

        int UpdateResume(ResumeModel resume);

        bool DeleteResume(int resumeId);

        int AddSkillToResume(int resumeId, SkillModel skill);

        int AddJobToResume(int resumeId, JobModel job);

        int AddEducationToResume(int resumeId, EducationModel education);

        int AddLanguageToResume(int resumeId, LanguageModel language);

        int AddCertificateToResume(int resumeId, CertificateModel certificate);

        bool RemoveResumeRelatedEntity<T>(int id)
            where T : ResumeRelatedEntity;
    }
}