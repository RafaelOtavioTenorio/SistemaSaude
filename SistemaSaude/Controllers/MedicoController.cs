using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaSaude.Models;

namespace SistemaSaude.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<MedicoModel>> BuscarTodosMedicos()
        {
            return Ok();
        }
    }
}
