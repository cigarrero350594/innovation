using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace exaInnovation.Models.Configuracion
{
    public class TareasConfig : IEntityTypeConfiguration<Tareas>
    {
        public void Configure(EntityTypeBuilder<Tareas> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(prop => prop.Nombre)
                .HasMaxLength(80)
                .IsRequired();

            //builder.Property<DateTime>("FechaCreacion")
            //        .HasDefaultValueSql("GetDate()")
            //        .HasColumnType("datetime2");

        }
    }
}
