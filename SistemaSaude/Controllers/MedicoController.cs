using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaSaude.Models;
using SistemaSaude.Repositorios;
using SistemaSaude.Repositorios.Interfaces;

namespace SistemaSaude.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoRepositorio _medicoRepositorio;
        public MedicoController(IMedicoRepositorio MedicoRepositorio)
        {
            _medicoRepositorio = MedicoRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<MedicoModel>>> BuscarTodosMedicos()
        {
            List<MedicoModel> Medicos = await _medicoRepositorio.BuscarTodosMedicos();
            return Ok(Medicos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<MedicoModel>>> BuscarMedicoPorId(int id)
        {
            MedicoModel Medico = await _medicoRepositorio.BuscarMedicoPorID(id);
            return Ok(Medico);
        }

        [HttpPost]
        public async Task<ActionResult<MedicoModel>> Cadastrar([FromBody] MedicoModel MedicoModel)
        {
            MedicoModel Medico = await _medicoRepositorio.AdicionarMedico(MedicoModel);
            return Ok(Medico);
        }

        [HttpPut]
        public async Task<ActionResult<MedicoModel>> Atualizar([FromBody] MedicoModel medicoModel, int id)
        {
            medicoModel.Id = id;
            MedicoModel medico = await _medicoRepositorio.AtualizarMedico(medicoModel, id);
            return Ok(medico);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MedicoModel>> Apagar(int id)
        {
            bool apagado = await _medicoRepositorio.ApagarMedico(id);
            return Ok(apagado);
        }
    }
}
