using Aibest.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aibest.Business.Services
{
    public class ResumeGradeService
    {
        public async Task<string> GradeResume(ResumeModel resume)
        {
            var api = new OpenAI_API.OpenAIAPI("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");

            var languages = string.Join("\n", resume.Languages.Select(x => x.Name + " Level: " + x.Level));

            var jobs = string.Join("\n",
                resume.Jobs.Select(x =>
                    "Company name: " + x.CompanyName + " Position: " + x.Position + " Description: " + x.Description +
                    " Begin year: " + x.BeginYear + " End year: " + x.EndYear));

            var educations = string.Join("\n",
                resume.Educations.Select(x =>
                    "School name: " + x.Name + "Country: " + x.Country + " Major: " + x.Major + " Begin year: " +
                    x.BeginYear + " End year: " + x.EndYear));

            var skills = string.Join(", ", resume.Skills.Select(x => x.Name));
            var certificates = string.Join("\n",
                resume.Certificates.Select(x =>
                    "Name " + x.Name + "Issued Year " + x.IssuedYear + "Description " + x.Description));

            var resumeString = $"Name: {resume.FirstName} {resume.LastName}\n" +
                               $"Email: {resume.EmailAddress}\n" +
                               $"Phone: {resume.PhoneNumber}\n" +
                               $"Address: {resume.Address}\n" +
                               $"Personal Description: {resume.Description}\n" +
                               $"Languages : {languages}\n" +
                               $"Educations: {educations}\n" +
                               $"Skills: {skills}\n" +
                               $"Past work experience:\n  {jobs}\n" +
                               $"Certificates: {certificates}\n";

            var chat = api.Chat.CreateConversation();
            chat.AppendSystemMessage(
                "You grade resumes based on industry standards and some data: Name, Email address, phone number, personal description, Languages and their respective level of knowledge, education, skills, past work experience including the name of the company and the position, certificates and tell the user if something is missing and what to improve in the resume, in no more than 2 sentences. In the following format: Hello (First name), Your resume is Perfect/Great/Good/Ok/Bad, you need more/less information for .");
            chat.AppendUserInput(resumeString);
            string response = await chat.GetResponseFromChatbotAsync();
            return response;
        }
    }
}
