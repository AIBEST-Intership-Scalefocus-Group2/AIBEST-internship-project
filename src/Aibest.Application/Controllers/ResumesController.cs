using Microsoft.AspNetCore.Mvc;
using Aibest.Business.Models;
using Aibest.Business.Services;
using Aibest.Data;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Aibest.Application.Controllers
{
    [Route("/resumes/")]
    public class ResumesController : Controller
    {
        private readonly IResumeService _resumeService;
        private readonly ILogger<ResumesController> _logger;

        public ResumesController(IResumeService resumeService, ILogger<ResumesController> logger)
        {
            _resumeService = resumeService;
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            var resumes = _resumeService.GetResumes();
            string errorMessage = TempData["ErrorMessage"] as string;

            if (!string.IsNullOrEmpty(errorMessage))
            {

                ModelState.AddModelError(string.Empty, errorMessage);
            }

            return View(resumes);
        }

        [HttpGet("add")]
        public IActionResult AddResume()
        {
            var viewModel = new ResumeModel();

            return View(viewModel);
        }

        [HttpGet("{id}/edit")]
        public IActionResult Edit([FromRoute] int id)
        {
            ResumeModel resume = _resumeService.GetResume(id);

            if (resume != null)
            {
                return View(resume);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("edit-personal-information")]
        public IActionResult EditPersonalInformation([FromForm(Name = "ResumeId")] int resumeId,[FromForm] ResumeModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = resumeId;
                bool isSuccess = _resumeService.UpdateResume(model);

                if (isSuccess)
                {
                    return RedirectToEdit(model.Id);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to edit the personal information in the resume.");
                }
            }

            return RedirectToEdit(resumeId);
        }

        [HttpPost("add")]
        public IActionResult AddResume(ResumeModel model)
        {
            if (ModelState.IsValid)
            {
                bool isSuccess = _resumeService.CreateResume(model);

                if (isSuccess)
                {
                    model.Id = _resumeService.GetResumes().LastOrDefault().Id;
                    return RedirectToEdit(model.Id);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to create the resume.");
                }
            }

            return View();
        }

        [HttpPost("delete")]
        public IActionResult DeleteResume([FromForm(Name = "ResumeId")]int resumeId)
        {

            bool isSuccess = _resumeService.DeleteResume(resumeId);

            if (isSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to delete the resume.";
                return RedirectToAction("Index");
            }
        }

        [HttpPost("add-language")]
        public IActionResult AddLanguage([FromForm(Name = "ResumeId")] int resumeId, [FromForm] LanguageModel model, [FromForm(Name = "level")] string level)
        {
            if (ModelState.IsValid)
            {
                bool isSuccess = _resumeService.AddLanguageToResume(resumeId, model,level);

                if (isSuccess)
                {
                    return RedirectToEdit(resumeId);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to add the language to the resume.");
                }
            }

            return RedirectToEdit(resumeId);
        }

        [HttpPost("add-skill")]
        public IActionResult AddSkill([FromForm(Name = "ResumeId")] int resumeId, [FromForm]SkillModel model)
        {
            if (ModelState.IsValid)
            {
                bool isSuccess = _resumeService.AddSkillToResume(resumeId, model);

                if (isSuccess)
                {
                    return RedirectToEdit(resumeId);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to add the skill to the resume.");
                }
            }

            return RedirectToEdit(resumeId);
        }

        [HttpPost("add-certificate")]
        public IActionResult AddCertificate([FromForm(Name = "ResumeId")] int resumeId, [FromForm] CertificateModel model)
        {
            if (ModelState.IsValid)
            {
                bool isSuccess = _resumeService.AddCertificateToResume(resumeId, model);

                if (isSuccess)
                {
                    return RedirectToEdit(resumeId);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to add the certificate to the resume.");
                }
            }

            return RedirectToEdit(resumeId);
        }

        [HttpPost("add-education")]
        public IActionResult AddEducation([FromForm(Name = "ResumeId")] int resumeId, [FromForm]EducationModel model)
        {
            if (ModelState.IsValid)
            {
                bool isSuccess = _resumeService.AddEducationToResume(resumeId, model);

                if (isSuccess)
                {
                    return RedirectToEdit(resumeId);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to add the education to the resume.");
                }
            }

            return RedirectToEdit(resumeId);
        }

        [HttpPost("add-job")]
        public IActionResult AddJob([FromForm(Name = "ResumeId")] int resumeId, [FromForm] JobModel model)
        {
            if (ModelState.IsValid)
            {
                bool isSuccess = _resumeService.AddJobToResume(resumeId, model);

                if (isSuccess)
                {
                    return RedirectToEdit(resumeId);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to add the job to the resume.");
                }
            }

            return RedirectToEdit(resumeId);
        }

        [HttpPost("delete-certificate")]
        public IActionResult DeleteCertificate([FromForm(Name = "ResumeId")] int resumeId, [FromForm(Name = "CertificateId")] int certificateId)
        {
            bool isSuccess = _resumeService.RemoveResumeRelatedEntity<Certificate>(certificateId);

            if (isSuccess)
            {
                return RedirectToEdit(resumeId);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to delete the certificate.");
            }

            return RedirectToEdit(resumeId);
        }

        [HttpPost("delete-education")]
        public IActionResult DeleteEducation([FromForm(Name = "ResumeId")] int resumeId, [FromForm(Name = "EducationId")] int educationId)
        {
            bool isSuccess = _resumeService.RemoveResumeRelatedEntity<Education>(educationId);

            if (isSuccess)
            {
                return RedirectToEdit(resumeId);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to delete the education.");
            }

            return RedirectToEdit(resumeId);
        }

        [HttpPost("delete-job")]
        public IActionResult DeleteJob([FromForm(Name = "ResumeId")] int resumeId, [FromForm(Name = "JobId")] int jobId)
        {
            bool isSuccess = _resumeService.RemoveResumeRelatedEntity<Job>(jobId);

            if (isSuccess)
            {
                return RedirectToEdit(resumeId);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to delete the job.");
            }

            return RedirectToEdit(resumeId);
        }

        [HttpPost]
        [Route("delete-language")]
        public IActionResult DeleteLanguage([FromForm(Name = "ResumeId")] int resumeId, [FromForm(Name = "LanguageId")] int languageId)
        {
            bool isSuccess = _resumeService.RemoveResumeRelatedEntity<Language>(languageId);

            if (isSuccess)
            {
                return RedirectToEdit(resumeId);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to delete the language.");
            }

            return RedirectToEdit(resumeId);
        }

        [HttpPost]
        [Route("delete-skill")]
        public IActionResult DeleteSkill([FromForm(Name = "SkillId")] int skillId, [FromForm(Name = "ResumeId")] int resumeId)
        {
            bool isSuccess = _resumeService.RemoveResumeRelatedEntity<Skill>(skillId);

            if (isSuccess)
            {
                return RedirectToEdit(resumeId);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to delete the skill.");
            }

            return RedirectToEdit(resumeId);
        }

        private IActionResult RedirectToEdit(int resumeId)
        {
            return RedirectToAction("Edit", new { id = resumeId });
        }

    }
}

