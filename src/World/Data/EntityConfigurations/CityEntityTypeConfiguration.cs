using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using World.Entities;

namespace World.Data.EntityConfigurations;

public class CityEntityTypeConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> entityTypeBuilder)
    {
        entityTypeBuilder.ToTable(nameof(City));
        entityTypeBuilder.HasOne(c => c.State).WithMany(r => r.Cities).OnDelete(DeleteBehavior.NoAction);
        entityTypeBuilder.HasOne(c => c.Country).WithMany(r => r.Cities).OnDelete(DeleteBehavior.NoAction);
        var date = new DateTime(1970, 1, 1, 0, 0, 0);
        entityTypeBuilder.HasData(
            new City { Id = 1, Name = "Brussels", StateId = 1, CountryId = 1, Latitude = 50.8503, Longitude = 4.3517, CreatedOn = date },
            new City { Id = 2, Name = "Antwerp", StateId = 1, CountryId = 1, Latitude = 51.2194, Longitude = 4.4025, CreatedOn = date },
            new City { Id = 3, Name = "Paris", StateId = 2, CountryId = 2, Latitude = 48.8566, Longitude = 2.3522, CreatedOn = date },
            new City { Id = 4, Name = "Lyon", StateId = 2, CountryId = 2, Latitude = 45.7640, Longitude = 4.8357, CreatedOn = date },
            new City { Id = 5, Name = "Los Angeles", StateId = 3, CountryId = 3, Latitude = 34.0522, Longitude = -118.2437, CreatedOn = date },
            new City { Id = 6, Name = "San Francisco", StateId = 3, CountryId = 3, Latitude = 37.7749, Longitude = -122.4194, CreatedOn = date },
            new City { Id = 7, Name = "Berlin", StateId = 4, CountryId = 4, Latitude = 52.5200, Longitude = 13.4050, CreatedOn = date },
            new City { Id = 8, Name = "Madrid", StateId = 5, CountryId = 5, Latitude = 40.4168, Longitude = -3.7038, CreatedOn = date },
            new City { Id = 9, Name = "Rome", StateId = 6, CountryId = 6, Latitude = 41.9028, Longitude = 12.4964, CreatedOn = date },
            new City { Id = 10, Name = "Tokyo", StateId = 7, CountryId = 7, Latitude = 35.6895, Longitude = 139.6917, CreatedOn = date },
            new City { Id = 11, Name = "Sydney", StateId = 8, CountryId = 8, Latitude = -33.8688, Longitude = 151.2093, CreatedOn = date },
            new City { Id = 12, Name = "São Paulo", StateId = 9, CountryId = 9, Latitude = -23.5505, Longitude = -46.6333, CreatedOn = date },
            new City { Id = 13, Name = "London", StateId = 10, CountryId = 10, Latitude = 51.5072, Longitude = -0.1276, CreatedOn = date },
            new City { Id = 14, Name = "Toronto", StateId = 11, CountryId = 11, Latitude = 43.6510, Longitude = -79.3470, CreatedOn = date },
            new City { Id = 15, Name = "Cape Town", StateId = 12, CountryId = 12, Latitude = -33.9249, Longitude = 18.4241, CreatedOn = date },
            new City { Id = 16, Name = "New Delhi", StateId = 13, CountryId = 13, Latitude = 28.6139, Longitude = 77.2090, CreatedOn = date },
            new City { Id = 17, Name = "Ghent", StateId = 1, CountryId = 1, Latitude = 51.0543, Longitude = 3.7174, CreatedOn = date },
            new City { Id = 18, Name = "Nice", StateId = 2, CountryId = 2, Latitude = 43.7102, Longitude = 7.2620, CreatedOn = date },
            new City { Id = 19, Name = "San Diego", StateId = 3, CountryId = 3, Latitude = 32.7157, Longitude = -117.1611, CreatedOn = date },
            new City { Id = 20, Name = "Hamburg", StateId = 4, CountryId = 4, Latitude = 53.5511, Longitude = 9.9937, CreatedOn = date },
            new City { Id = 21, Name = "Barcelona", StateId = 5, CountryId = 5, Latitude = 41.3851, Longitude = 2.1734, CreatedOn = date },
            new City { Id = 22, Name = "Milan", StateId = 6, CountryId = 6, Latitude = 45.4642, Longitude = 9.1900, CreatedOn = date },
            new City { Id = 23, Name = "Osaka", StateId = 7, CountryId = 7, Latitude = 34.6937, Longitude = 135.5023, CreatedOn = date },
            new City { Id = 24, Name = "Melbourne", StateId = 8, CountryId = 8, Latitude = -37.8136, Longitude = 144.9631, CreatedOn = date },
            new City { Id = 25, Name = "Rio de Janeiro", StateId = 9, CountryId = 9, Latitude = -22.9068, Longitude = -43.1729, CreatedOn = date },
            new City { Id = 26, Name = "Birmingham", StateId = 10, CountryId = 10, Latitude = 52.4862, Longitude = -1.8904, CreatedOn = date },
            new City { Id = 27, Name = "Vancouver", StateId = 11, CountryId = 11, Latitude = 49.2827, Longitude = -123.1207, CreatedOn = date },
            new City { Id = 28, Name = "Durban", StateId = 12, CountryId = 12, Latitude = -29.8587, Longitude = 31.0218, CreatedOn = date },
            new City { Id = 29, Name = "Mumbai", StateId = 13, CountryId = 13, Latitude = 19.0760, Longitude = 72.8777, CreatedOn = date },
            new City { Id = 30, Name = "Liège", StateId = 1, CountryId = 1, Latitude = 50.6326, Longitude = 5.5797, CreatedOn = date },
            new City { Id = 31, Name = "Toulouse", StateId = 2, CountryId = 2, Latitude = 43.6047, Longitude = 1.4442, CreatedOn = date },
            new City { Id = 32, Name = "Sacramento", StateId = 3, CountryId = 3, Latitude = 38.5816, Longitude = -121.4944, CreatedOn = date },
            new City { Id = 33, Name = "Munich", StateId = 4, CountryId = 4, Latitude = 48.1351, Longitude = 11.5820, CreatedOn = date },
            new City { Id = 34, Name = "Valencia", StateId = 5, CountryId = 5, Latitude = 39.4699, Longitude = -0.3763, CreatedOn = date },
            new City { Id = 35, Name = "Naples", StateId = 6, CountryId = 6, Latitude = 40.8518, Longitude = 14.2681, CreatedOn = date },
            new City { Id = 36, Name = "Kyoto", StateId = 7, CountryId = 7, Latitude = 35.0116, Longitude = 135.7681, CreatedOn = date }

            );
    }
}