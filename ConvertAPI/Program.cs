using System.Reflection;
using ConvertAPI.Contexts.Converts.Application.CommandServices;
using ConvertAPI.Contexts.Converts.Application.QueryServices;
using ConvertAPI.Contexts.Converts.Domain.Repositories;
using ConvertAPI.Contexts.Converts.Domain.Services;
using ConvertAPI.Contexts.Converts.Infrastructure.Repositories;
using ConvertAPI.Contexts.Shared.Domain.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// CORS Configuration - Allow All
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// Controllers with Exception Filter
builder.Services.AddControllers(options => { options.Filters.Add<ConvertExceptionFilter>(); })
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
            new BadRequestObjectResult(new { message = "Invalid request data." });
    });

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Repository 
builder.Services.AddSingleton<IConvertRepository, ConvertRepository>();

// Application Services
builder.Services.AddScoped<IConvertCommandService, ConvertCommandService>();
builder.Services.AddScoped<IConvertQueryService, ConvertQueryService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // API general information
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Convert API - Kilograms to Pounds",
        Description = "An ASP.NET Core Web API for converting kilograms to pounds with scalable DDD architecture"
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    options.UseInlineDefinitionsForEnums();
});

var app = builder.Build();

// Swagger
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Convert API v1");
    options.RoutePrefix = "swagger";

    options.DocumentTitle = "Convert API Documentation";
    options.DisplayRequestDuration();
    options.EnableDeepLinking();
    options.EnableFilter();
    options.ShowExtensions();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app.MapOpenApi();

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();