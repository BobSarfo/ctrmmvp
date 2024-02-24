using ctrmmvp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ctrmmvp.Data.Configurations
{
    public class ArcContractConfiguration : IEntityTypeConfiguration<ArcContract>
    {
        public void Configure(EntityTypeBuilder<ArcContract> builder)
        {
            // Table name
            builder.ToTable("ArcContract");

            // Primary key
            builder.HasKey(e => new { e.CompanyID, e.ContractNbr }).HasName("ArcContract_PK");

            // Column configurations
            builder.Property(e => e.CompanyID).IsRequired().HasDefaultValue(0);
            builder.Property(e => e.BranchID).IsRequired();
            builder.Property(e => e.ContractNbr).IsRequired();
            // Add other properties and configurations...

            // Ignore tstamp column
            builder.Ignore(e => e.tstamp);

            // Index
            builder.HasIndex(e => new { e.NoteID, e.CompanyID }).HasName("ArcContract_NoteID");

            // Defaults
            builder.Property(e => e.CompanyID).HasDefaultValue(0);
            builder.Property(e => e.LineCntr).HasDefaultValue(0);

            // Relationships (if any)
        }
    }
}