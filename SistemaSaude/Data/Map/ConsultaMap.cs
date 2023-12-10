using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaSaude.Models;

namespace SistemaSaude.Data.Map
{
    public class ConsultaMap : IEntityTypeConfiguration<ConsultaModel>
    {
        public void Configure(EntityTypeBuilder<ConsultaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TipoConsulta).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DataConsulta).IsRequired().HasMaxLength(8);
            builder.Property(x => x.LocalConsulta).IsRequired().HasMaxLength(255);
            builder.Property(x => x.MedicoId).IsRequired();
            builder.Property(x => x.PacienteId).IsRequired();
            builder.Property(x => x.Status).IsRequired();

            builder.HasOne(x => x.Paciente);
            builder.HasOne(x => x.Medico);
        }
    }
}
