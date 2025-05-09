using Microsoft.EntityFrameworkCore;
using World.Data;
using World.Entities;

namespace World.GraphQl.Mutations;

[MutationType]
public static class CountryMutation
{
    public static async Task<Country> CreateCountry([Service] WorldContext context, CountryAddRequest request, CancellationToken cancellationToken)
    {
        var country = context.Countries.Add(new Country
        {
            Name = request.Name,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            Iso3 = request.Iso3,
            IsMonarchy = request.IsMonarchy,
            DeclarationOfIndependence = request.DeclarationOfIndependence,
            CreatedDate = request.CreatedDate
        });
        await context.SaveChangesAsync(cancellationToken);
        return country.Entity;
    }
    
    public static async Task<Country> UpdateCountry([Service] WorldContext context, CountryUpdateRequest request, CancellationToken cancellationToken)
    {
        var country = await context.Countries.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
        country.Name = request.Name;
        country.Latitude = request.Latitude;
        country.Longitude = request.Longitude;
        country.Iso3 = request.Iso3;
        country.IsMonarchy = request.IsMonarchy;
        country.DeclarationOfIndependence = request.DeclarationOfIndependence;
        country.CreatedDate = request.CreatedDate;
        context.Update(country);
        await context.SaveChangesAsync(cancellationToken);
        return country;
    }
    
    public static async Task<int> DeleteCountry([Service] WorldContext context, int id, CancellationToken cancellationToken)
    {
        var country = await context.Countries.FirstAsync(c => c.Id == id, cancellationToken);
        context.Remove(country);
        return await context.SaveChangesAsync(cancellationToken);
    }
}

public record CountryAddRequest(string Name, double Latitude, double Longitude, string Iso3, bool IsMonarchy, DateOnly DeclarationOfIndependence, DateTime CreatedDate);
public record CountryUpdateRequest(int Id, string Name, double Latitude, double Longitude, string Iso3, bool IsMonarchy, DateOnly DeclarationOfIndependence, DateTime CreatedDate);
