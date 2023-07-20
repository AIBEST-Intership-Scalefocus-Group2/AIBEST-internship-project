using Aibest.Business.Models;
using Microsoft.Extensions.Configuration;
using OpenAI_API;
using System.Linq;
using System.Threading.Tasks;

namespace Aibest.Business.Services
{
    public class ResumeGradeService : IResumeGradeService
    {
        private readonly OpenAIAPI openAiApi;

        public ResumeGradeService(IConfiguration configuration)
        {
            var apiAuth = new APIAuthentication(
                configuration["ChatGpt:ApiKey"],
                configuration["ChatGpt:OpenAiOrganizationId"]);

            this.openAiApi = new OpenAIAPI(apiAuth);
        }

        public async Task<string> GradeResume(ResumeModel resume)
        {
            var languages = string.Join("\n", resume.Languages.Select(x => x.Name + " Level: " + x.Level));

            var jobs = string.Join("\n",
                resume.Jobs.Select(x =>
                    "Company name: " + x.CompanyName + " Position: " + x.Position + " Description: " + x.Description +
                    " Begin year: " + x.BeginYear + " End year: " + x.EndYear));

            var educations = string.Join("\n",
                resume.Educations.Select(x =>
                    "School name: " + x.Name + " Major: " + x.Major + " Begin year: " +
                    x.BeginYear + " Graduation year: " + x.EndYear));

            var skills = string.Join(", ", resume.Skills.Select(x => x.Name));
            var certificates = string.Join("\n",
                resume.Certificates.Select(x =>
                    "Name " + x.Name + " Issued Year " + x.IssuedYear + " Description " + x.Description));

            var resumeString = $"Name: {resume.FirstName} {resume.LastName}\n" +
                               $"Email: {resume.EmailAddress}\n" +
                               $"Phone: {resume.PhoneNumber}\n" +
                               $"Address: {resume.Address}\n" +
                               $"Languages : {languages}\n" +
                               $"Educations: {educations}\n" +
                               $"Skills: {skills}\n" +
                               $"Past work experience:\n  {jobs}\n" +
                               $"Certificates: {certificates}\n";

            var chat = this.openAiApi.Chat.CreateConversation();
            chat.Model = "gpt-3.5-turbo";
            chat.AppendSystemMessage(
                "You grade resume on this data: Name, Email address, phone number, Languages and Level( A1, A2, B1, B2, C1, C2), education school names and majors, skills, past work experience including the name of the company and the position, certificates and tell the user if something is missing in no more than 2 sentences. In the following format: Hello (First name), Your resume is Perfect/Great/Good/Ok/Bad, you need more/less information for .");
            chat.AppendUserInput(resumeString);
            string response = await chat.GetResponseFromChatbotAsync();
            return response;
        }
    }
}
