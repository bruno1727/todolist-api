using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TaskManager.Controllers
{
    [Route("api/task")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class TaskController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new List<string>
            {
                "Escovar os dentes",
                "Tomar café da manha",
                "Ir trabalhar",
                "Voltar para casa",
                "Jantar",
                "Dormir",
            };
        }
    }
}
