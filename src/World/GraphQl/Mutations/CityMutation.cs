using Microsoft.EntityFrameworkCore;
using World.Data;
using World.Entities;

namespace World.GraphQl.Mutations;

[MutationType]
public static class CityMutation
{
    public static async Task<City> CreateCity([Service] WorldContext context, CityAddRequest request, CancellationToken cancellationToken)
    {
        var city = context.Cities.Add(new City(request.Name, request.Latitude, request.Longitude, request.StateId, request.CountryId));
        await context.SaveChangesAsync(cancellationToken);
        return city.Entity;
    }
    
    public static async Task<City> UpdateCity([Service] WorldContext context, CityUpdateRequest request, CancellationToken cancellationToken)
    {
        var city = await context.Cities.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
        city.Name = request.Name;
        city.Latitude = request.Latitude;
        city.Longitude = request.Longitude;
        city.StateId = request.StateId;
        city.CountryId = request.CountryId;
        context.Update(city);
        await context.SaveChangesAsync(cancellationToken);
        return city;
    }
    
    public static async Task<int> DeleteCity([Service] WorldContext context, int id, CancellationToken cancellationToken)
    {
        var city = await context.Cities.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        context.Remove(city);
        return await context.SaveChangesAsync(cancellationToken);
    }
}

public record CityAddRequest(string Name, double Latitude, double Longitude, int StateId, int CountryId);
public record CityUpdateRequest(int Id, string Name, double Latitude, double Longitude, int StateId, int CountryId);
