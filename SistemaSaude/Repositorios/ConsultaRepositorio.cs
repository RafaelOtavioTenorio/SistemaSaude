using Microsoft.EntityFrameworkCore;
using SistemaSaude.Data;
using SistemaSaude.Models;
using SistemaSaude.Repositorios.Interfaces;

namespace SistemaSaude.Repositorios
{
    public class ConsultaRepositorio : IConsultaRepositorio
    {
        private readonly SistemaSaudeDBContext _dbContext;
        public ConsultaRepositorio(SistemaSaudeDBContext sistemaSaudeDBContext)
        {
            _dbContext = sistemaSaudeDBContext;
        }

        public async Task<ConsultaModel> BuscarConsultaPorID(int id)
        {
            return await _dbContext.Consultas
                .Include(x => x.Paciente)
                .Include(x => x.Medico)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ConsultaModel>> BuscarTodasConsultas()
        {
            return await _dbContext.Consultas
                .Include(x => x.Paciente)
                .Include(x => x.Medico)
                .ToListAsync();
        }

        public async Task<ConsultaModel> AdicionarConsulta(ConsultaModel consulta)
        {
            await _dbContext.Consultas.AddAsync(consulta);
            await _dbContext.SaveChangesAsync();

            return consulta;
        }

        public async Task<ConsultaModel> AtualizarConsulta(ConsultaModel consulta, int id)
        {
            ConsultaModel consultaPorId = await BuscarConsultaPorID(id);

            if(consultaPorId == null)
            {
                throw new Exception($"Consulta com ID: {id} não foi encontrado no banco de dados.");
            }

            consultaPorId.TipoConsulta = consulta.TipoConsulta;
            consultaPorId.DataConsulta = consulta.DataConsulta;
            consultaPorId.LocalConsulta = consulta.LocalConsulta;
            consultaPorId.Status = consulta.Status;
            consultaPorId.PacienteId = consulta.PacienteId;
            consultaPorId.MedicoId = consulta.MedicoId;


            _dbContext.Consultas.Update(consultaPorId);
            await _dbContext.SaveChangesAsync();

            return consultaPorId;
        }

        public async Task<bool> ApagarConsulta(int id)
        {
            ConsultaModel consultaPorId = await BuscarConsultaPorID(id);

            if (consultaPorId == null)
            {
                throw new Exception($"Consulta com ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Consultas.Remove(consultaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
