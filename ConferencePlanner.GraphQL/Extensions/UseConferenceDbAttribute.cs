using ConferencePlanner.GraphQL.Database;

using HotChocolate.Types.Descriptors;

using System.Reflection;

namespace ConferencePlanner.GraphQL.Extensions;

public class UseConferenceDbAttribute : ObjectFieldDescriptorAttribute
{
    public override void OnConfigure(
            IDescriptorContext context,
            IObjectFieldDescriptor descriptor,
            MemberInfo member)
    {
        descriptor.UseDbContext<ConferenceDb>();
    }
}
