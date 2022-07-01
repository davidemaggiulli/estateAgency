using EstateAgency.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstateAgency.Core.Configurations
{
    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.ToTable("Unit");
            builder.HasKey(x => x.Codice);

            builder.HasOne(x => x.Owner)
                .WithMany(x => x.Units) 
                .HasForeignKey(x => x.OwnerId);

            builder.Property(x => x.DataIns)
                .HasColumnType("date");
        }
    }
}
