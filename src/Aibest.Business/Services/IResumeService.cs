using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aibest.Business.Models;

namespace Aibest.Business.Services
{
    public interface IResumeService
    {
        bool CreateResume(ResumeModel resume);

        bool UpdateResume(ResumeModel resume);

        bool DeleteResume(int resumeId);

        ResumeModel GetResumeById(int resumeId);

        bool AddSkillToResume(ResumeModel resume, SkillModel skill);

        bool RemoveSkillFromResume(int skillId);

        bool AddJobToResume(ResumeModel resume,JobModel job);

        bool RemoveJob(int jobId);

        bool AddEducationToResume(ResumeModel resume,EducationModel education);

        bool RemoveEducation(int educationId);

        bool AddLanguageToResume(ResumeModel resume,LanguageModel language);

        bool RemoveLanguage(int languageId);

        bool AddCertificateToResume(ResumeModel resume,CertificateModel certificate);

        bool RemoveCertificate(int certificateId);

        List<ResumeModel> GetResumesByUserId(string userId);
        
        List<CertificateModel> GetCertificatesByResumeId(int resumeId);
        
        List<JobModel> GetJobsByResumeId(int resumeId);
        
        List<LanguageModel> GetLanguagesByResumeId(int resumeId);
        
        List<SkillModel> GetSkillsByResumeId(int resumeId);
        
        List<EducationModel> GetEducationsByResumeId(int resumeId);
    }
}
