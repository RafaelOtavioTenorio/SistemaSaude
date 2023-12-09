using SistemaSaude.Models;

namespace SistemaSaude.Repositorios.Interfaces
{
    public interface IPacienteRepositorio
    {
        Task<List<PacienteModel>> BuscarTodosPacientes();
        Task<PacienteModel> BuscarPacientePorID(int id);
        Task<PacienteModel> AdicionarPaciente(PacienteModel paciente);
        Task<PacienteModel> AtualizarPaciente(PacienteModel paciente, int id);
        Task<bool> ApagarPaciente(int id);
    }
}
