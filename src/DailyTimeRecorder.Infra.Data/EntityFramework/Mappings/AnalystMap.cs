using DailyTimeRecorder.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DailyTimeRecorder.Infra.Data.EntityFramework.Mappings
{
    public class AnalystMap : IEntityTypeConfiguration<Analyst>
    {
        public void Configure(EntityTypeBuilder<Analyst> builder)
        {
            builder.ToTable("Analysts")
                .HasKey(analyst => analyst.Id);

            builder.Property(analyst => analyst.Id)
                .HasColumnName("Id");

            builder.Property(analyst => analyst.Name)
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(analyst => analyst.Email)
                .HasColumnType("nvarchar(254)")
                .HasMaxLength(254)
                .IsRequired();
        }
    }
}
