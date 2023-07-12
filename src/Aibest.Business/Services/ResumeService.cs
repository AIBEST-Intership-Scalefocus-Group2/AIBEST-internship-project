using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Aibest.Business.Services
{
    public class ResumeService : IResumeService
    {
        public bool AddCertificate(int resumeId, string name, DateTime issuedYear, string description)
        {
            throw new NotImplementedException();
        }

        public bool AddEducation(int resumeId, string name, string country, string major, DateTime beginYear, DateTime endYear)
        {
            throw new NotImplementedException();
        }

        public bool AddJob(string name, int resumeId, string companyName, string position, string description, DateTime beginYear, DateTime endYear)
        {
            throw new NotImplementedException();
        }

        public bool AddLanguage(int resumeId, string name, string level)
        {
            throw new NotImplementedException();
        }

        public bool AddSkillToResume(int resumeId, string name)
        {
            throw new NotImplementedException();
        }

        public bool CreateResume(string resumeName, int userId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteResume(int resumeId)
        {
            throw new NotImplementedException();
        }

        public bool GetResumeById(int resumeId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveCertificate(int resumeId, int certificateId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveEducation(int resumeId, int educationId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveJob(int resumeId, int jobId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveLanguage(int resumeId, int languageId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveSkillFromResume(int resumeId, int skillId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateResume(string FirstName, string MiddleName, string LastName, string Email, string PhoneNumber, string Address)
        {
            throw new NotImplementedException();
        }
    }
}
