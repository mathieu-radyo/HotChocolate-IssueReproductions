using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using World.Entities;

namespace World.Data.EntityConfigurations;

public class RegionEntityTypeConfiguration : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> entityTypeBuilder)
    {
        entityTypeBuilder.ToTable(nameof(Region));
        entityTypeBuilder.HasMany(c => c.SubRegions).WithOne(r => r.Region).OnDelete(DeleteBehavior.Cascade);
        entityTypeBuilder.HasData(
            new Region { Id = 1, Name = "Europe", WikiDataId = "Q46" },
            new Region { Id = 2, Name = "North America", WikiDataId = "Q49" },
            new Region { Id = 3, Name = "Asia", WikiDataId = "Q48" },
            new Region { Id = 4, Name = "Oceania", WikiDataId = "Q538" },
            new Region { Id = 5, Name = "South America", WikiDataId = "Q18" },
            new Region { Id = 6, Name = "Africa", WikiDataId = "Q15" }
        );
    }
}