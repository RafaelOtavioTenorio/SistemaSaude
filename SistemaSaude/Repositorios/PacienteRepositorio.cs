using Microsoft.EntityFrameworkCore;
using SistemaSaude.Data;
using SistemaSaude.Models;
using SistemaSaude.Repositorios.Interfaces;

namespace SistemaSaude.Repositorios
{
    public class PacienteRepositorio : IPacienteRepositorio
    {
        private readonly SistemaSaudeDBContext _dbContext;
        public PacienteRepositorio(SistemaSaudeDBContext sistemaSaudeDBContext)
        {
            _dbContext = sistemaSaudeDBContext;
        }

        public async Task<PacienteModel> BuscarPacientePorID(int id)
        {
            return await _dbContext.Pacientes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PacienteModel>> BuscarTodosPacientes()
        {
            return await _dbContext.Pacientes.ToListAsync();
        }

        public async Task<PacienteModel> AdicionarPaciente(PacienteModel paciente)
        {
            await _dbContext.Pacientes.AddAsync(paciente);
            await _dbContext.SaveChangesAsync();

            return paciente;
        }

        public async Task<PacienteModel> AtualizarPaciente(PacienteModel paciente, int id)
        {
            PacienteModel pacientePorId = await BuscarPacientePorID(id);

            if(pacientePorId == null)
            {
                throw new Exception($"Paciente com ID: {id} não foi encontrado no banco de dados.");
            }

            pacientePorId.Nome = paciente.Nome;
            pacientePorId.DataNasc = paciente.DataNasc;
            pacientePorId.RG = paciente.RG;
            pacientePorId.CartaoSUS = paciente.CartaoSUS;

            _dbContext.Pacientes.Update(pacientePorId);
            await _dbContext.SaveChangesAsync();

            return pacientePorId;
        }

        public async Task<bool> ApagarPaciente(int id)
        {
            PacienteModel pacientePorId = await BuscarPacientePorID(id);

            if (pacientePorId == null)
            {
                throw new Exception($"Paciente com ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Pacientes.Remove(pacientePorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
