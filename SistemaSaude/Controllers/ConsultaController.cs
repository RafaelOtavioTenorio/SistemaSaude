using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaSaude.Models;
using SistemaSaude.Repositorios;
using SistemaSaude.Repositorios.Interfaces;

namespace SistemaSaude.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaRepositorio _consultaRepositorio;
        public ConsultaController(IConsultaRepositorio consultaRepositorio)
        {
            _consultaRepositorio = consultaRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<ConsultaModel>>> BuscarTodasConsultas()
        {
            List<ConsultaModel> Consultas = await _consultaRepositorio.BuscarTodasConsultas();
            return Ok(Consultas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ConsultaModel>>> BuscarConsultaPorId(int id)
        {
            ConsultaModel Consulta = await _consultaRepositorio.BuscarConsultaPorID(id);
            return Ok(Consulta);
        }

        [HttpPost]
        public async Task<ActionResult<ConsultaModel>> Cadastrar([FromBody] ConsultaModel ConsultaModel)
        {
            ConsultaModel Consulta = await _consultaRepositorio.AdicionarConsulta(ConsultaModel);
            return Ok(Consulta);
        }

        [HttpPut]
        public async Task<ActionResult<ConsultaModel>> Atualizar([FromBody] ConsultaModel consultaModel, int id)
        {
            consultaModel.Id = id;
            ConsultaModel consulta = await _consultaRepositorio.AtualizarConsulta(consultaModel, id);
            return Ok(consulta);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ConsultaModel>> Apagar(int id)
        {
            bool apagado = await _consultaRepositorio.ApagarConsulta(id);
            return Ok(apagado);
        }
    }
}
