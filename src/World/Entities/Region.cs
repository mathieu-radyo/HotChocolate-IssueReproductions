namespace World.Entities;

public class Region
{
    public int Id { get; set; }
    public string? WikiDataId { get; set; }
    public string Name { get; set; } = default!;
    
    public ICollection<Country> Countries = new HashSet<Country>();
    public ICollection<SubRegion> SubRegions = new HashSet<SubRegion>();
}