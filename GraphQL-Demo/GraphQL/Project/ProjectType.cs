using GraphQL.Types;

namespace GraphQL_Demo.Models;

public class ProjectType : ObjectGraphType<Project>
{
    public ProjectType()
    {
        Name = "Project";   
        Description = "Project Type";
        Field(x => x.Id, type: typeof(IdGraphType)).Description("The ID of the Project.");
        Field(x => x.Name).Description("The name of the Project.");
        Field(x => x.CreatedBy).Description("The description of the Project.");
    }
}