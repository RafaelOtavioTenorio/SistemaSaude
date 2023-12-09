using Microsoft.EntityFrameworkCore;
using SistemaSaude.Data;
using SistemaSaude.Models;
using SistemaSaude.Repositorios.Interfaces;

namespace SistemaSaude.Repositorios
{
    public class MedicoRepositorio : IMedicoRepositorio
    {
        private readonly SistemaSaudeDBContext _dbContext;
        public MedicoRepositorio(SistemaSaudeDBContext sistemaSaudeDBContext)
        {
            _dbContext = sistemaSaudeDBContext;
        }
        public async Task<MedicoModel> BuscarMedicoPorID(int id)
        {
            return await _dbContext.Medicos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<MedicoModel>> BuscarTodosMedicos()
        {
            return await _dbContext.Medicos.ToListAsync();
        }
        public async Task<MedicoModel> AdicionarMedico(MedicoModel medico)
        {
            await _dbContext.Medicos.AddAsync(medico);
            await _dbContext.SaveChangesAsync();

            return medico;
        }

        public async Task<MedicoModel> AtualizarMedico(MedicoModel medico, int id)
        {
            MedicoModel medicoPorId = await BuscarMedicoPorID(id);

            if (medicoPorId == null)
            {
                throw new Exception($"Medico com ID: {id} não foi encontrado no banco de dados.");
            }

            medicoPorId.Nome = medico.Nome;
            medicoPorId.DataNasc = medico.DataNasc;
            medicoPorId.RG = medico.RG;
            medicoPorId.Cargo = medico.Cargo;

            _dbContext.Medicos.Update(medicoPorId);
            await _dbContext.SaveChangesAsync();

            return medicoPorId;
        }

        public async Task<bool> ApagarMedico(int id)
        {
            MedicoModel medicoPorId = await BuscarMedicoPorID(id);

            if (medicoPorId == null)
            {
                throw new Exception($"Medico com ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Medicos.Remove(medicoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        
    }
}
