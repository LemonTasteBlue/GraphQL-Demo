using GraphQL_Demo.Models;
using GraphQL.MicrosoftDI;
using GraphQL.Server;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ProjectSchema>(services =>
    new ProjectSchema(new SelfActivatingServiceProvider(services)));

builder.Services.AddGraphQL(options =>
    {
        // true if you want to get additional result data
        options.EnableMetrics = false;
    }
).AddSystemTextJson();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "GraphQL_Demo", Version = "v1"}); });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GraphQL_Demo v1"));
    app.UseGraphQLAltair();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.UseGraphQL<ProjectSchema>();

app.Run();