using System;

namespace Aibest.Application.Models
{
    public class CertificateModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime IssuedYear { get; set; }
        public string Description { get; set; }

    }
}
