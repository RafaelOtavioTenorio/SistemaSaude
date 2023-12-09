using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaSaude.Models;

namespace SistemaSaude.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<PacienteModel>> BuscarTodosPacientes()
        {
            return Ok();
        }
    }
}
