using Microsoft.AspNetCore.Mvc;
using Nest;

namespace Notes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AuthController : ControllerBase
    {
        
        
        [HttpGet("elastick")]
        public string Get()
        {
            return "merhaba";

        }

    }

  
}
