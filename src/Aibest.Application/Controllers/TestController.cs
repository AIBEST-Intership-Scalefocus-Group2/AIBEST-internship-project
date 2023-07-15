using Aibest.Business.Models;
using Aibest.Business.Services;
using Aibest.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Aibest.Application.Controllers
{
    public class TestController : Controller
    {
        private readonly IResumeService resumeService;

        public TestController(IResumeService resumeService)
        {
            this.resumeService = resumeService;
        }

        [Authorize]
        [HttpPost]
        [Route("/test")]
        public IActionResult Index([FromForm] ResumeModel model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(ModelState.Values.Select(x => x.Errors));
            }

            return Ok(this.resumeService.CreateResume(model));
        }

        [Authorize]
        [HttpPost]
        [Route("/test/resumes")]
        public IActionResult AllResumesUser([FromForm] string userId)
        {
            if (!ModelState.IsValid)
            {
                return Ok(ModelState.Values.Select(x => x.Errors));
            }

            return Ok(this.resumeService.GetResumes());
        }

        [Authorize]
        [HttpGet]
        [Route("/test/resumebyid/{id}")]
        public IActionResult ResumeFromId(int id)
        {
            return Ok(this.resumeService.GetResume(id));
        }
        //write test http requests for all methods in ResumeService
        [Authorize]
        [HttpPost]
        [Route("/test/addskill/{id}")]
        public IActionResult AddSkillToResume(int id, [FromForm] SkillModel model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(ModelState.Values.Select(x => x.Errors));
            }

            return Ok(this.resumeService.AddSkillToResume(id, model));
        }
        [Authorize]
        [HttpPost]
        [Route("/test/addjob/{id}")]
        public IActionResult AddJobToResume(int id, [FromForm] JobModel model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(ModelState.Values.Select(x => x.Errors));
            }

            return Ok(this.resumeService.AddJobToResume(id, model));
        }
        [Authorize]
        [HttpPost]
        [Route("/test/addeducation/{id}")]
        public IActionResult AddEducationToResume(int id, [FromForm] EducationModel model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(ModelState.Values.Select(x => x.Errors));
            }

            return Ok(this.resumeService.AddEducationToResume(id, model));
        }
        [Authorize]
        [HttpPost]
        [Route("/test/addlanguage/{id}")]
        public IActionResult AddLanguageToResume(int id, [FromForm] LanguageModel model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(ModelState.Values.Select(x => x.Errors));
            }

            return Ok(this.resumeService.AddLanguageToResume(id, model));
        }
        [Authorize]
        [HttpPost]
        [Route("/test/addcertificate/{id}")]
        public IActionResult AddCertificateToResume(int id, [FromForm] CertificateModel model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(ModelState.Values.Select(x => x.Errors));
            }

            return Ok(this.resumeService.AddCertificateToResume(id, model));
        }


        [Authorize]
        [HttpPost]
        [Route("/test/removeskill/{id}")]
        public IActionResult Remove(int id)
        {
            if (!ModelState.IsValid)
            {
                return Ok(ModelState.Values.Select(x => x.Errors));
            }

            return Ok(this.resumeService.RemoveResumeRelatedEntity<Skill>(id));
        }
    }
}
