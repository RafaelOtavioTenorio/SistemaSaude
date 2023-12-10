using SistemaSaude.Models;

namespace SistemaSaude.Repositorios.Interfaces
{
    public interface IConsultaRepositorio
    {
        Task<List<ConsultaModel>> BuscarTodasConsultas();
        Task<ConsultaModel> BuscarConsultaPorID(int id);
        Task<ConsultaModel> AdicionarConsulta(ConsultaModel consulta);
        Task<ConsultaModel> AtualizarConsulta(ConsultaModel consulta, int id);
        Task<bool> ApagarConsulta(int id);
    }
}
