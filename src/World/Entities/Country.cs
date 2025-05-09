namespace World.Entities;

public class Country
{
    private List<City> _cities;
    private List<State> _states;
    public int Id { get;  set; }
    public string Name { get;  set; }
    public string Iso3 { get;  set; }
    public string? NumericCode { get;  set; }
    public string? Iso2 { get;  set; }
    public string? PhoneCode { get;  set; }
    public string? Capital { get;  set; }
    public string? Currency { get;  set; }
    public string? CurrencyName { get;  set; }
    public string? CurrencySymbol { get;  set; }
    public string? Tld { get;  set; }
    public string? Native { get;  set; }
    public string? Nationality { get;  set; }
    public double Latitude { get;  set; }
    public double Longitude { get;  set; }
    public string? Emoji { get;  set; }
    public string? EmojiU { get;  set; }
    public string? WikiDataId { get;  set; }
    public bool IsMonarchy { get; set; }
    public DateOnly DeclarationOfIndependence { get;  set; }
    public DateTime CreatedDate { get;  set; }

    public Country()
    {
        _states = [];
        _cities = [];
    }
    
    public List<City> Cities { get; init; } = [];
    public List<State> States { get; init; } = [];

}