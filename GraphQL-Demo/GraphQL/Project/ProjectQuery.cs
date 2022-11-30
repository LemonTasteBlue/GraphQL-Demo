using GraphQL.Types;

namespace GraphQL_Demo.Models;

public class ProjectQuery : ObjectGraphType
{
    public ProjectQuery()
    {
        Field<ListGraphType<ProjectType>>("project", resolve: context => new List<Project>
        {
            new Project {Id = Guid.NewGuid(), Name = "Project 1", CreatedBy = "Pjotr"},
            new Project {Id = Guid.NewGuid(), Name = "Project 2", CreatedBy = "Wacław"},
            new Project {Id = Guid.NewGuid(), Name = "Project 3", CreatedBy = "Tomasz"},
        });
    }
}