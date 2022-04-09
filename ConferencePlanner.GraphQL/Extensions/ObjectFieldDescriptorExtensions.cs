using ConferencePlanner.GraphQL.Database;

using Microsoft.EntityFrameworkCore;

namespace ConferencePlanner.GraphQL.Extensions;

public static class ObjectFieldDescriptorExtensions
{
    public static IObjectFieldDescriptor UseDbContext<TContext>(
        this IObjectFieldDescriptor descriptor)
        where TContext : DbContext
    {
        return descriptor.UseScopedService(
            service => service.GetRequiredService<IDbContextFactory<TContext>>().CreateDbContext(),
            (service, context) => context.DisposeAsync());
    }
}
