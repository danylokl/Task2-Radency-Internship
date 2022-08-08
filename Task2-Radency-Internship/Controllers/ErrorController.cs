using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task2_Radency_Internship.Controllers
{
    
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public ActionResult Error() => Problem();
    }
}
