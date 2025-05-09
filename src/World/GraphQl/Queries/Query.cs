using GreenDonut.Data;
using HotChocolate.Data;
using HotChocolate.Resolvers;
using HotChocolate.Types.Pagination;
using Microsoft.EntityFrameworkCore;
using World.Data;
using World.Entities;

namespace World.GraphQl.Queries;

[QueryType]
public static partial class Query
{
    [UseOffsetPaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public static IQueryable<Country> GetCountriesWithOffsetPaginationAsync([Service] WorldContext context)
    {
        return context.Countries.AsNoTracking();
    }
    
    [UseConnection]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public static async Task<PageConnection<Country>> GetCountriesAsync([Service] WorldContext context, IResolverContext t, PagingArguments pagingArguments, QueryContext<Country> query,  CancellationToken cancellationToken = default)
    {
        var page = await context.Countries.AsNoTracking()
            .With(query, c => c.IfEmpty(i => i.AddAscending(e => e.Id)))
            .Project(t)
            .ToPageAsync(pagingArguments, cancellationToken);
        return new PageConnection<Country>(page);
    }
    
    [UseConnection]
    [UseFiltering]
    [UseSorting]
    public static async Task<PageConnection<City>> GetCitiesAsync([Service] WorldContext context, PagingArguments pagingArguments, QueryContext<City> query,  CancellationToken cancellationToken = default)
    {
        var page = await context.Cities.AsNoTracking()
            .With(query, c => c.IfEmpty(i => i.AddAscending(e => e.Id)))
            .ToPageAsync(pagingArguments, cancellationToken);
        return new PageConnection<City>(page);
    }
    
    [UseConnection]
    [UseFiltering]
    [UseSorting]
    public static async Task<PageConnection<SubRegion>> GetSubRegionsAsync([Service] WorldContext context, PagingArguments pagingArguments, QueryContext<SubRegion> query,  CancellationToken cancellationToken = default)
    {
        var page = await context.SubRegions.AsNoTracking()
            .With(query, c => c.IfEmpty(i => i.AddAscending(e => e.Id)))
            .ToPageAsync(pagingArguments, cancellationToken);
        return new PageConnection<SubRegion>(page);
    }
}