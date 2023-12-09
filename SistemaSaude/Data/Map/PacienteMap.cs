using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaSaude.Models;

namespace SistemaSaude.Data.Map
{
    public class PacienteMap : IEntityTypeConfiguration<PacienteModel>
    {
        public void Configure(EntityTypeBuilder<PacienteModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DataNasc).IsRequired().HasMaxLength(8);
            builder.Property(x => x.RG).IsRequired().HasMaxLength(10);
            builder.Property(x => x.CartaoSUS).IsRequired().HasMaxLength(15);
        }
    }
}
