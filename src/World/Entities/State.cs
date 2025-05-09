namespace World.Entities;

public class State
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string? FipsCode { get; set; }
    public string? Iso2 { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string? WikiDataId { get; set; }
    public Country Country { get; set; } = default!;
    public int CountryId { get; set; } 
    public ICollection<City> Cities = new HashSet<City>();
}