using CrmallTeste.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmallTeste.Infra.Persistence.Map
{
    public class PersonalMap : IEntityTypeConfiguration<Personal>
    {
        public void Configure(EntityTypeBuilder<Personal> builder)
        {
            builder.ToTable("Personal");
            builder.Property(p => p.Name).HasMaxLength(250).IsRequired();
            builder.Property(p => p.Number).HasMaxLength(6).IsRequired();
            builder.Property(p => p.Neighborhood).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Complement).HasMaxLength(50);
            builder.Property(p => p.City).HasMaxLength(250).IsRequired();
            builder.Property(p => p.State).HasMaxLength(2).IsRequired();
            builder.Property(p => p.ZipCode).HasMaxLength(9).IsRequired();
            builder.Property(p => p.Cpf).HasMaxLength(14).IsRequired();
            builder.Property(p => p.Street).HasMaxLength(250).IsRequired();


        }
    }
}
