using System.Text.Json.Serialization;

namespace Tema.Models.DTOs.Applicants
{
    public class ApplicantDTO : IApplicantDTO
    {
        public string FinderEmail { get; set; }
        public long PostId { get; set; }

        [JsonConstructor]
        public ApplicantDTO() { }
    }
}
