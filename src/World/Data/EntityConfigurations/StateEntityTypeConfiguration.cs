using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using World.Entities;

namespace World.Data.EntityConfigurations;

public class StateEntityTypeConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> entityTypeBuilder)
    {
        entityTypeBuilder.ToTable(nameof(State));
        entityTypeBuilder.HasOne(c => c.Country).WithMany(r => r.States).OnDelete(DeleteBehavior.Cascade);
        entityTypeBuilder.HasMany(c => c.Cities).WithOne(r => r.State).OnDelete(DeleteBehavior.Cascade);
        entityTypeBuilder.HasData(
            new State { Id = 1, Name = "Brussels-Capital", CountryId = 1 },
            new State { Id = 2, Name = "Île-de-France", CountryId = 2 },
            new State { Id = 3, Name = "California", CountryId = 3 },
            new State { Id = 4, Name = "Berlin", CountryId = 4 },
            new State { Id = 5, Name = "Community of Madrid", CountryId = 5 },
            new State { Id = 6, Name = "Lazio", CountryId = 6 },
            new State { Id = 7, Name = "Tokyo Metropolis", CountryId = 7 },
            new State { Id = 8, Name = "New South Wales", CountryId = 8 },
            new State { Id = 9, Name = "São Paulo", CountryId = 9 },
            new State { Id = 10, Name = "Greater London", CountryId = 10 },
            new State { Id = 11, Name = "Ontario", CountryId = 11 },
            new State { Id = 12, Name = "Western Cape", CountryId = 12 },
            new State { Id = 13, Name = "Delhi", CountryId = 13 }
        );
    }
}