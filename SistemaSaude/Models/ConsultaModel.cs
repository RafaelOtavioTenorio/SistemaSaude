namespace SistemaSaude.Models
{
    public class ConsultaModel
    {
        public int ID { get; set; }
        public string? TipoConsulta { get; set; }
        public string? DataConsulta { get; set; }
        public int Status { get; set; }
        public MedicoModel? Medico { get; set; }
        public PacienteModel? Paciente { get; set; }

    }
}
