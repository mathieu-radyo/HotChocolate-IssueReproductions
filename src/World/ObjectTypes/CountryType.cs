using World.Entities;

namespace World.ObjectTypes;

[ObjectType<Country>]
public static partial class CountryType
{
    static partial void Configure(IObjectTypeDescriptor<Country> descriptor)
    {
        descriptor.BindFieldsImplicitly();
    }
}
