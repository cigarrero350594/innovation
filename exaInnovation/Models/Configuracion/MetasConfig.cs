using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using exaInnovation.Models;
using System;

namespace exaInnovation.Models.Configuracion
{
    public class MetasConfig : IEntityTypeConfiguration<Metas>
    {   
        public void Configure(EntityTypeBuilder<Metas> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(prop => prop.Nombre)
            .HasMaxLength(80)
            .IsRequired();

            builder.HasMany(x => x.Tareas)
                .WithOne(x => x.Metas)
                .HasForeignKey(x => x.MetasId);

            builder.Property<DateTime>("FechaCreacion")
                    .HasDefaultValueSql("GetDate()")
                    .HasColumnType("datetime2");

        }
    }
}
