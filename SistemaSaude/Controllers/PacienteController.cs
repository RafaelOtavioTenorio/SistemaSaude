using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaSaude.Models;
using SistemaSaude.Repositorios;
using SistemaSaude.Repositorios.Interfaces;

namespace SistemaSaude.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepositorio _pacienteRepositorio;
        public PacienteController(IPacienteRepositorio pacienteRepositorio)
        {
            _pacienteRepositorio = pacienteRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<PacienteModel>>> BuscarTodos()
        {
            List<PacienteModel> pacientes = await _pacienteRepositorio.BuscarTodosPacientes();
            return Ok(pacientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<PacienteModel>>> BuscarPorId(int id)
        {
            PacienteModel paciente = await _pacienteRepositorio.BuscarPacientePorID(id);
            return Ok(paciente);
        }

        [HttpPost]
        public async Task<ActionResult<PacienteModel>> Cadastrar([FromBody] PacienteModel pacienteModel)
        {
            PacienteModel paciente = await _pacienteRepositorio.AdicionarPaciente(pacienteModel);
            return Ok (paciente);
        }

        [HttpPut]
        public async Task<ActionResult<PacienteModel>> Atualizar([FromBody] PacienteModel pacienteModel, int id)
        {
            pacienteModel.Id = id;
            PacienteModel paciente = await _pacienteRepositorio.AtualizarPaciente(pacienteModel, id);
            return Ok(paciente);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PacienteModel>> Apagar(int id)
        {
            bool apagado = await _pacienteRepositorio.ApagarPaciente(id);
            return Ok(apagado);
        }
    }
}
