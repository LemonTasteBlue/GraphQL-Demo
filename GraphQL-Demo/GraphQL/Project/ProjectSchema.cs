using GraphQL.Types;

namespace GraphQL_Demo.Models;

public class ProjectSchema : Schema
{
    public ProjectSchema(IServiceProvider provider) : base(provider)
    {
        Query = provider.GetRequiredService<ProjectQuery>();
    }
}