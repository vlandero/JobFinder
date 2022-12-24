using Tema.Models.DTOs.Companies;

namespace Tema.Models.DTOs.Request.Users.Register
{
    public class SeekerRequestRegisterDTO : UserRequestRegisterDTO
    {
        public CompanyDTO? CompanyDTO { get; set; }
        public bool Created { get; set; }
        
    }
}
