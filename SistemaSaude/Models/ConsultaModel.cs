using SistemaSaude.Enums;

namespace SistemaSaude.Models
{
    public class ConsultaModel
    {
        public int Id { get; set; }
        public string? TipoConsulta { get; set; }
        public string? DataConsulta { get; set; }
        public string? LocalConsulta { get; set; }
        public StatusTarefa Status { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public virtual PacienteModel Paciente { get; set; }
        public virtual MedicoModel Medico { get; set; }

    }
}
