using SistemaSaude.Models;

namespace SistemaSaude.Repositorios.Interfaces
{
    public interface IMedicoRepositorio
    {
        Task<List<MedicoModel>> BuscarTodosMedicos();
        Task<MedicoModel> BuscarMedicoPorID(int id);
        Task<MedicoModel> AdicionarMedico(MedicoModel medico);
        Task<MedicoModel> AtualizarMedico(MedicoModel medico, int id);
        Task<bool> ApagarMedico(int id);
    }
}
