namespace App.Models
{
    public class ResumeBaseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstAndMiddleName { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }

        public byte[] ImageData { get; set; }
        //public static string ToDataUrl(byte[] imageData)
        //{
        //    return $"data:image/png;base64,{Convert.ToBase64String(imageData)}";
        //}

        public string PhoneNumber { get; set; }
        public List<SkillModel> Skills { get; set; }
        public List<WorkModel> Work { get; set; }
        public List<EducationModel> Education { get; set; }
        public List<LanguageModel> Language { get; set; }
        public List<CertificateModel> Certificates { get; set; }


    }
}
