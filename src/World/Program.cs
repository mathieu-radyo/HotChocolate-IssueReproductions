using Microsoft.EntityFrameworkCore;
using World.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WorldContext>(o =>
{
    o.UseSqlite(builder.Configuration.GetConnectionString("World"));
    o.EnableDetailedErrors();
    var logger = LoggerFactory.Create(b => b.AddConsole());
    o.UseLoggerFactory(logger);
});

builder
    .AddGraphQL()
    .AddWorldTypes()
    .ModifyPagingOptions(p =>
    {
        p.EnableRelativeCursors = true;
        p.IncludeTotalCount = true;
    })
    .AddPagingArguments()
    .AddQueryContext()
    .AddSorting()
    .AddFiltering()
    .AddProjections();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseRouting();
app.MapGraphQL();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<WorldContext>();
    dbContext.Database.Migrate();
}
await app.RunWithGraphQLCommandsAsync(args);
