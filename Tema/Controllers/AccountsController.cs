using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        [HttpGet("aa")]
        public int aa()
        {
            return 1;
        }
    }
}
