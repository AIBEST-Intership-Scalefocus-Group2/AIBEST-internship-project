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
        bool CreateResume(string resumeName, int userId);

        bool UpdateResume(string FirstName, string MiddleName, string LastName, string Email, string PhoneNumber, string Address);

        bool DeleteResume(int resumeId);

        bool GetResumeById(int resumeId);

        bool AddSkillToResume(int resumeId, string name);

        bool RemoveSkillFromResume(int resumeId, int skillId);

        bool AddJob(string name, int resumeId, string companyName, string position, string description, DateTime beginYear, DateTime endYear);

        bool RemoveJob(int resumeId, int jobId);

        bool AddEducation(int resumeId, string name, string country, string major, DateTime beginYear, DateTime endYear);

        bool RemoveEducation(int resumeId, int educationId);

        bool AddLanguage(int resumeId, string name, string level);

        bool RemoveLanguage(int resumeId, int languageId);

        bool AddCertificate(int resumeId, string name, DateTime issuedYear, string description);

        bool RemoveCertificate(int resumeId, int certificateId);
    }
}
