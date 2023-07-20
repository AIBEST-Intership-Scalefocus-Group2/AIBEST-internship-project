using Aibest.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aibest.Business.Services
{
    public interface IResumeGradeService
    {
        Task<string> GradeResume(ResumeModel resume);
    }
}
