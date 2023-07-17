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
        public IActionResult EditPersonalInformation([FromRoute] int id, ResumeModel model)
        {
            if (ModelState.IsValid)
            {
                int isSuccess = _resumeService.UpdateResume(model);

                if (isSuccess != -1)
                {
                    return RedirectToAction("Edit", new { id = model.Id });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to update the resume.");
                }
            }

            return View(model);
        }

        [HttpPost("/resumes/create-resume")]
        public IActionResult CreateResume(ResumeModel model)
        {
            if (ModelState.IsValid)
            {
                int result = _resumeService.CreateResume(model);

                if (result != -1)
                {
                    return RedirectToAction("Edit", new { id = model.Id });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to add the language to the resume.");
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
                return View("Delete", resumeId);
            }
        }

        [HttpPost("/resumes/{resumeId:int}/add-language")]
        public IActionResult AddLanguage([FromRoute] int resumeId, LanguageModel model)
        {
            if (ModelState.IsValid)
            {
                int result = _resumeService.AddLanguageToResume(resumeId, model);

                if (result != -1)
                {
                    return RedirectToAction("Edit", new { id = resumeId });
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
                int result = _resumeService.AddSkillToResume(resumeId, model);

                if (result != -1)
                {
                    return RedirectToAction("Edit", new { id = resumeId });
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
                int result = _resumeService.AddCertificateToResume(resumeId, model);

                if (result != -1)
                {
                    return RedirectToAction("Edit", new { id = resumeId });
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
                int result = _resumeService.AddEducationToResume(resumeId, model);

                if (result != -1)
                {
                    return RedirectToAction("Edit", new { id = resumeId });
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
                int result = _resumeService.AddJobToResume(resumeId, model);

                if (result != -1)
                {
                    return RedirectToAction("Edit", new { id = resumeId });
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
            bool result = _resumeService.RemoveResumeRelatedEntity<Certificate>(certificateId);

            if (result)
            {
                return RedirectToAction("Edit", new { id = resumeId });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to delete the certificate.");
            }

            return RedirectToAction("Edit", new { id = resumeId });
        }

        [HttpPost("/resumes/{resumeId:int}/delete-education/{educationId}")]
        public IActionResult DeleteEducation([FromRoute] int resumeId, [FromRoute] int educationId)
        {
            bool result = _resumeService.RemoveResumeRelatedEntity<Education>(educationId);

            if (result)
            {
                return RedirectToAction("Edit", new { id = resumeId });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to delete the education.");
            }

            return RedirectToAction("Edit", new { id = resumeId });
        }

        [HttpPost("/resumes/{resumeId:int}/delete-job/{jobId}")]
        public IActionResult DeleteJob([FromRoute] int resumeId, [FromRoute] int jobId)
        {
            bool result = _resumeService.RemoveResumeRelatedEntity<Job>(jobId);

            if (result)
            {
                return RedirectToAction("Edit", new { id = resumeId });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to delete the job.");
            }

            return RedirectToAction("Edit", new { id = resumeId });
        }

        [HttpPost]
        [Route("/resumes/{resumeId:int}/delete-language/{languageId}")]
        public IActionResult DeleteLanguage([FromRoute] int resumeId, [FromRoute] int languageId)
        {
            bool result = _resumeService.RemoveResumeRelatedEntity<Language>(languageId);

            if (result)
            {
                return RedirectToAction("Edit", new { id = resumeId });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to delete the language.");
            }

            return RedirectToAction("Edit", new { id = resumeId });
        }

        [HttpPost]
        [Route("/resumes/{resumeId:int}/delete-skill/{skillId}")]
        public IActionResult DeleteSkill([FromRoute] int resumeId, [FromRoute] int skillId)
        {
            bool result = _resumeService.RemoveResumeRelatedEntity<Skill>(skillId);

            if (result)
            {
                return RedirectToAction("Edit", new { id = resumeId });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to delete the skill.");
            }

            return RedirectToAction("Edit", new { id = resumeId });
        }
    }
}

