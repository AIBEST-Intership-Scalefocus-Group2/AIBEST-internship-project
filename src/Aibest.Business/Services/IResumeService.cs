using Aibest.Business.Models;
using Aibest.Data;
using System.Collections.Generic;

namespace Aibest.Business.Services
{
    public interface IResumeService
    {
        byte[] GetResumePicture(int resumeId);

        IEnumerable<ResumeModel> GetResumes();

        ResumeModel GetResume(int resumeId);

        bool CreateResume(ResumeModel resume);

        bool UpdateResume(ResumeModel resume);

        bool DeleteResume(int resumeId);

        bool AddSkillToResume(int resumeId, SkillModel skill);

        bool AddJobToResume(int resumeId, JobModel job);

        bool AddEducationToResume(int resumeId, EducationModel education);

        bool AddLanguageToResume(int resumeId, LanguageModel language,string level);

        bool AddCertificateToResume(int resumeId, CertificateModel certificate);

        bool RemoveResumeRelatedEntity<T>(int id)
            where T : ResumeRelatedEntity;
    }
}