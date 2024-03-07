using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace UniversityRankingAPI.Models.Entities.Configurations
{
    public class UniveristyDataEntityTypeConfiguration : IEntityTypeConfiguration<UniversityData>
    {
        public void Configure(EntityTypeBuilder<UniversityData> builder)
        {
            builder
                .Property(b => b.Id)
                .IsRequired();
        }
    }
}
