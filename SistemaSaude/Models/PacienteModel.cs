namespace SistemaSaude.Models
{
    public class PacienteModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? DataNasc { get; set; }
        public string? RG { get; set; }
        public int CartaoSUS { get; set; }
    }
}
