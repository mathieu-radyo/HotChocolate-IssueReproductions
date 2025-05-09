using World.Entities;

namespace World.ObjectTypes;

[ObjectType<City>]
public static partial class CityType
{
    static partial void Configure(IObjectTypeDescriptor<City> descriptor)
    {
        descriptor.BindFieldsImplicitly();
    }
}

