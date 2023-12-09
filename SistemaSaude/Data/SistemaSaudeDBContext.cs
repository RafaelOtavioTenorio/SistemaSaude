using Microsoft.EntityFrameworkCore;
using SistemaSaude.Data.Map;
using SistemaSaude.Models;

namespace SistemaSaude.Data
{
    public class SistemaSaudeDBContext : DbContext
    {

        public SistemaSaudeDBContext(DbContextOptions<SistemaSaudeDBContext> options)
            : base(options)
        { 
        }  

        public DbSet<PacienteModel> Pacientes { get; set; }
        public DbSet<MedicoModel> Medicos { get; set; }
        public DbSet<ConsultaModel> Consultas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PacienteMap());
            modelBuilder.ApplyConfiguration(new MedicoMap());
            modelBuilder.ApplyConfiguration(new ConsultaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
