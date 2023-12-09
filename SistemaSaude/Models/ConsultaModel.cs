using SistemaSaude.Enums;

namespace SistemaSaude.Models
{
    public class ConsultaModel
    {
        public int Id { get; set; }
        public string? TipoConsulta { get; set; }
        public string? DataConsulta { get; set; }
        public string? LocalConsulta { get; set; }
        public string? Medico { get; set; }
        public string? Paciente { get; set; }
        public StatusTarefa Status { get; set; }

    }
}
