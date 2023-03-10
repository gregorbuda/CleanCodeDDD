using Compliance.Api.OperationFilters;
using Compliance.Api.Utils;
using Compliance.Application;
using Compliance.Domain.Models;
using Compliance.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Example.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddTransient<LoggingApiMiddleware>();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Example Microservice",
        Description = "Example Microservice",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    options.IncludeXmlComments("Models.xml");
    options.IncludeXmlComments("Application.xml");
    options.OperationFilter<RemoveVersionParameterFilter>();
    options.DocumentFilter<ReplaceVersionWithExactValueInPathFilter>();
    options.EnableAnnotations();
});


builder.Services.AddMvc()
.SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
           .ConfigureApiBehaviorOptions(options =>
           {
               options.InvalidModelStateResponseFactory = context =>
               {
                   var problems = new CustomBadRequest(context);
                   return new BadRequestObjectResult(problems);
               };
           });

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseClassWithNoImplementationMiddlewareExtensions();
    app.UseSwagger();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json",
                          "Swagger XML Api Demo v1");
    });
}
else
{
    app.UseClassWithNoImplementationMiddlewareExtensions();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();