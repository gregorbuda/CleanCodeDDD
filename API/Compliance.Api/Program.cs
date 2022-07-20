using Compliance.Application;
using Compliance.Application.Responses;
using Compliance.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API",
        Description = "An ASP.NET Core Web API for managing ToDo items",
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
});

builder.Services.AddMvc(setupAction =>
{
    setupAction.Filters.Add(
        new ProducesResponseTypeAttribute(typeof(ProblemDetailsBadRequest), StatusCodes.Status400BadRequest));
    setupAction.Filters.Add(
        new ProducesResponseTypeAttribute(typeof(ProblemDetailsNotFound), StatusCodes.Status404NotFound));
    setupAction.Filters.Add(
        new ProducesResponseTypeAttribute(typeof(ProblemDetailsNotAcceptable), StatusCodes.Status406NotAcceptable));
    setupAction.Filters.Add(
        new ProducesResponseTypeAttribute(typeof(ProblemDetailsInternalServerError), StatusCodes.Status500InternalServerError));
    setupAction.Filters.Add(
        new ProducesDefaultResponseTypeAttribute(typeof(ProblemDetailsDefault)));
    setupAction.Filters.Add(
        new ProducesResponseTypeAttribute(typeof(ProblemDetailsUnauthorized), StatusCodes.Status401Unauthorized));

    setupAction.Filters.Add(
        new AuthorizeFilter());

    setupAction.ReturnHttpNotAcceptable = true;

    setupAction.OutputFormatters.Add(new XmlSerializerOutputFormatter());

    var jsonOutputFormatter = setupAction.OutputFormatters
        .OfType<SystemTextJsonOutputFormatter>().FirstOrDefault();

    if (jsonOutputFormatter != null)
    {
        // remove text/json as it isn't the approved media type
        // for working with JSON at API level
        if (jsonOutputFormatter.SupportedMediaTypes.Contains("text/json"))
        {
            jsonOutputFormatter.SupportedMediaTypes.Remove("text/json");
        }
    }

}).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();