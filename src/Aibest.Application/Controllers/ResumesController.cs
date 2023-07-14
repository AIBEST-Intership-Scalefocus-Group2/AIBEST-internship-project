using Microsoft.AspNetCore.Mvc;
using Aibest.Business.Models;
using Aibest.Business.Services;

namespace Aibest.Application.Controllers
{
    public class ResumesController : Controller
    {
        private readonly IResumeService _resumeService;

        public ResumesController(IResumeService resumeService)
        {
            _resumeService = resumeService;
        }

        // GET: /Resumes/Edit/5
        public IActionResult Edit([FromRoute] int id)
        {
            ResumeModel resume = _resumeService.GetResumeById(id);

            if (resume != null)
            {
                return View(resume);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: /Resumes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, ResumeModel model)
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

        // POST: /Resumes/AddLanguage/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // POST: /Resumes/AddSkill/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // POST: /Resumes/AddCertificate/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // POST: /Resumes/AddEducation/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // POST: /Resumes/AddJob/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // POST: /Resumes/DeleteCertificate/{resumeId}/{certificateId}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCertificate([FromRoute] int resumeId, [FromRoute] int certificateId)
        {
            int result = _resumeService.RemoveCertificate(certificateId);

            if (result != -1)
            {
                return RedirectToAction("Edit", new { id = resumeId });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to delete the certificate.");
            }

            return RedirectToAction("Edit", new { id = resumeId });
        }

        // POST: /Resumes/DeleteEducation/{resumeId}/{educationId}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEducation([FromRoute] int resumeId, [FromRoute] int educationId)
        {
            int result = _resumeService.RemoveEducation(educationId);

            if (result != -1)
            {
                return RedirectToAction("Edit", new { id = resumeId });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to delete the education.");
            }

            return RedirectToAction("Edit", new { id = resumeId });
        }

        // POST: /Resumes/DeleteJob/{resumeId}/{jobId}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteJob([FromRoute] int resumeId, [FromRoute] int jobId)
        {
            int result = _resumeService.RemoveJob(jobId);

            if (result != -1)
            {
                return RedirectToAction("Edit", new { id = resumeId });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to delete the job.");
            }

            return RedirectToAction("Edit", new { id = resumeId });
        }

        // POST: /Resumes/DeleteLanguage/{resumeId}/{languageId}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteLanguage([FromRoute] int resumeId, [FromRoute] int languageId)
        {
            int result = _resumeService.RemoveLanguage(languageId);

            if (result != -1)
            {
                return RedirectToAction("Edit", new { id = resumeId });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to delete the language.");
            }

            return RedirectToAction("Edit", new { id = resumeId });
        }

        // POST: /Resumes/DeleteSkill/{resumeId}/{skillId}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSkill([FromRoute] int resumeId, [FromRoute] int skillId)
        {
            int result = _resumeService.RemoveSkill(skillId);

            if (result != -1)
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
