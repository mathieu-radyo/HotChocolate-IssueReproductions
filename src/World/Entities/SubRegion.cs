namespace World.Entities;

public class SubRegion
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? WikiDataId { get; set; }
    public Region Region { get; set; } = default!;
    public int RegionId { get; set; }
    public ICollection<Country> Countries = new HashSet<Country>();
}