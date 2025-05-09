using World.Entities;

namespace World.ObjectTypes;

[ObjectType<State>]
public static partial class StateType
{
    static partial void Configure(IObjectTypeDescriptor<State> descriptor)
    {
        descriptor.BindFieldsImplicitly();
    }
}
