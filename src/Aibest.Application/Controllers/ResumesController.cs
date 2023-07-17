using Microsoft.AspNetCore.Mvc;
using Aibest.Business.Models;
using Aibest.Business.Services;
using Aibest.Data;

namespace Aibest.Application.Controllers
{
    public class ResumesController : Controller
    {
        private readonly IResumeService _resumeService;

        public ResumesController(IResumeService resumeService)
        {
            _resumeService = resumeService;
        }

        [HttpGet("/resumes/{resumeId:int}/edit")]
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

        [HttpPost("/resumes/{resumeId:int}/edit-personal-information")]
        public IActionResult EditPersonalInformation([FromRoute] int resumeId, ResumeModel model)
        {
            if (ModelState.IsValid)
            {
                bool isSuccess = _resumeService.UpdateResume(model);

                if (isSuccess)
                {
                    return RedirectToEdit(model.Id);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to edit the personal information the resume.");
                }
            }

            return View("Edit", new { id = resumeId });
        }

        [HttpPost("/resumes/create-resume")]
        public IActionResult CreateResume(ResumeModel model)
        {
            if (ModelState.IsValid)
            {
                bool isSuccess = _resumeService.CreateResume(model);

                if (isSuccess)
                {
                    return RedirectToEdit(model.Id);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to create the resume.");
                }
            }

            return View("Edit", new { id = model.Id });
        }

        [HttpPost("/resumes/{resumeId:int}/delete-resume")]
        public IActionResult DeleteResume([FromRoute] int resumeId)
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

        [HttpGet("/resumes")]
        public IActionResult Index()
        {
            var resumes = _resumeService.GetResumes();
            string errorMessage = TempData["ErrorMessage"] as string;

            if (!string.IsNullOrEmpty(errorMessage))
            {

                ModelState.AddModelError(string.Empty, errorMessage);
            }
            return View(resumes);
        }

        [HttpPost("/resumes/{resumeId:int}/add-language")]
        public IActionResult AddLanguage([FromRoute] int resumeId, LanguageModel model)
        {
            if (ModelState.IsValid)
            {
                bool isSuccess = _resumeService.AddLanguageToResume(resumeId, model);

                if (isSuccess)
                {
                    return RedirectToEdit(resumeId);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to add the language to the resume.");
                }
            }

            return View("Edit", new { id = resumeId });
        }

        [HttpPost("/resumes/{resumeId:int}/add-skill")]
        public IActionResult AddSkill([FromRoute] int resumeId, SkillModel model)
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

            return View("Edit", new { id = resumeId });
        }

        [HttpPost("/resumes/{resumeId:int}/add-certificate")]
        public IActionResult AddCertificate([FromRoute] int resumeId, CertificateModel model)
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

            return View("Edit", new { id = resumeId });
        }

        [HttpPost("/resumes/{resumeId:int}/add-education")]
        public IActionResult AddEducation([FromRoute] int resumeId, EducationModel model)
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

            return View("Edit", new { id = resumeId });
        }

        [HttpPost("/resumes/{resumeId:int}/add-job")]
        public IActionResult AddJob([FromRoute] int resumeId, JobModel model)
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

            return View("Edit", new { id = resumeId });
        }

        [HttpPost("/resumes/{resumeId:int}/delete-certificate/{certificateId}")]
        public IActionResult DeleteCertificate([FromRoute] int resumeId, [FromRoute] int certificateId)
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

        [HttpPost("/resumes/{resumeId:int}/delete-education/{educationId}")]
        public IActionResult DeleteEducation([FromRoute] int resumeId, [FromRoute] int educationId)
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

        [HttpPost("/resumes/{resumeId:int}/delete-job/{jobId}")]
        public IActionResult DeleteJob([FromRoute] int resumeId, [FromRoute] int jobId)
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
        [Route("/resumes/{resumeId:int}/delete-language/{languageId}")]
        public IActionResult DeleteLanguage([FromRoute] int resumeId, [FromRoute] int languageId)
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
        [Route("/resumes/{resumeId:int}/delete-skill/{skillId}")]
        public IActionResult DeleteSkill([FromRoute] int resumeId, [FromRoute] int skillId)
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

