using ctrmmvp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ctrmmvp.Data.Configurations;

public class ArcContractLineConfiguration : IEntityTypeConfiguration<ArcContractLine>
{
    public void Configure(EntityTypeBuilder<ArcContractLine> builder)
    {
        builder.ToTable("ArcContractLine");

        // Primary key
        builder.HasKey(e => new { e.CompanyID, e.ContractNbr, e.SplitNbr }).HasName("ArcContractLine_PK");

        // Other indexes
        builder.HasIndex(e => new { e.NoteID, e.CompanyID }).HasName("ArcContractLine_NoteID").IsUnique(false);

        // Properties
        builder.Property(e => e.CompanyID).HasColumnName("CompanyID").IsRequired();
        builder.Property(e => e.ContractNbr).HasColumnName("ContractNbr").IsRequired().HasMaxLength(64);
        builder.Property(e => e.SplitNbr).HasColumnName("SplitNbr").IsRequired();
        builder.Property(e => e.SplitDate).HasColumnName("SplitDate").HasColumnType("datetime2(0)");
        builder.Property(e => e.ContractType).HasColumnName("ContractType").HasMaxLength(1);
        builder.Property(e => e.OriginalQty).HasColumnName("OriginalQty").HasColumnType("decimal(25, 6)");
        builder.Property(e => e.SplitQty).HasColumnName("SplitQty").HasColumnType("decimal(25, 6)");
        builder.Property(e => e.OpenQty).HasColumnName("OpenQty").HasColumnType("decimal(25, 6)");
        // Add other properties here...

        // Relationships (if any)

        // Default values and constraints (if any)
        builder.Property(e => e.CompanyID).HasDefaultValue(0);

        // Configure other constraints and defaults here...
    }
}