using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using World.Entities;

namespace World.Data.EntityConfigurations;

public class SubRegionEntityTypeConfiguration : IEntityTypeConfiguration<SubRegion>
{
    public void Configure(EntityTypeBuilder<SubRegion> entityTypeBuilder)
    {
        entityTypeBuilder.ToTable(nameof(SubRegion));
        entityTypeBuilder.HasOne(c => c.Region).WithMany(r => r.SubRegions).OnDelete(DeleteBehavior.NoAction);
        entityTypeBuilder.HasData(
            new SubRegion { Id = Guid.Parse("d92a1d17-ea43-4337-b443-741e74d9f2c1"), Name = "Western Europe", WikiDataId = "Q27574", RegionId = 1 },
            new SubRegion { Id = Guid.Parse("ee99e4a6-df46-40ac-a4ed-72bf3b44fbba"), Name = "Northern America", WikiDataId = "Q49", RegionId = 2 },
            new SubRegion { Id = Guid.Parse("bf3514e8-3509-43cc-80b6-b966a43e74ca"), Name = "Southern Asia", WikiDataId = "Q46169", RegionId = 3 },
            new SubRegion { Id = Guid.Parse("cf0da940-7235-4b1d-a8e8-9f5bf827a033"), Name = "Eastern Asia", WikiDataId = "Q4628", RegionId = 3 },
            new SubRegion { Id = Guid.Parse("601bd8dc-4908-4cee-8844-73792e32fd5e"), Name = "Australia and New Zealand", WikiDataId = "Q538", RegionId = 4 },
            new SubRegion { Id = Guid.Parse("47ce3e8b-61bc-4806-9499-01594ba19f1e"), Name = "South America", WikiDataId = "Q18", RegionId = 5 },
            new SubRegion { Id = Guid.Parse("cdeb1ec2-d13b-4359-9592-e36809ce3104"), Name = "Southern Africa", WikiDataId = "Q824", RegionId = 6 }
        );
    }
}