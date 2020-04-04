using Microsoft.EntityFrameworkCore;
using BL.TesteGol.Domain.Airplane.Airplane.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BL.TesteGol.Infra.Data.Airplane.Mappings
{
    public class AirplaneModelMapping : IEntityTypeConfiguration<AirplaneModel>
    {
        public void Configure(EntityTypeBuilder<AirplaneModel> builder)
        {
            builder.Property(p => p.Id)
                .IsRequired();

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Modelo)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.QtdPassageiros)
                .IsRequired();

            builder.Property(p => p.DataCriacao)
                .IsRequired();

            builder.Ignore(p => p.ValidationResult);

            builder.Ignore(p => p.CascadeMode);

            builder.ToTable("AirPlanes");
        }
    }
}