using System.Text.Json.Serialization;

namespace Tema.Models.DTOs.Request.Users.Register
{
    public class FinderRequestRegisterDTO : UserRequestRegisterDTO
    {
        public string? About { get; set; }
        public List<string> Skills { get; set; }
        [JsonConstructor]
        public FinderRequestRegisterDTO() { }
    }
}
