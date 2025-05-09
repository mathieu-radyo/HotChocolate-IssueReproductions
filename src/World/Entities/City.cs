namespace World.Entities;

public class City
{
    public int Id { get;  set; }
    public string Name { get;  set; } = default!;
    public double Latitude { get;  set; }
    public double Longitude { get;  set; }
    public string? WikiDataId { get;  set; }
    public State State { get;  set; } = default!;
    public int StateId { get;  set; }
    public Country Country { get;  set; } = default!;
    public int CountryId { get;  set; }
    
    public DateTime CreatedOn { get;  set; }

    public City() { }
    public City(string name, double latitude, double longitude, int stateId, int countryId) : this()
    {
        Name = name;
        Latitude = latitude;
        Longitude = longitude;
        StateId = stateId;
        CountryId = countryId;
        CreatedOn = DateTime.UtcNow;
    }
}