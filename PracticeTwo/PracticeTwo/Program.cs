using Serilog;
using PracticeTwo.BusinessLogic.Managers;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<PatientManager>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Alejandro Uriarte - PracticeTwo", Version = "v1" }); // Modificar el título aquí
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("C://Users//Alejandro//Documents//2024 - I//Certificacion I//PruebasGit//practiceTwo//PracticeTwo////DevelopmentLog-.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();
    app.UseSwagger();
    app.UseSwaggerUI();
    Log.Information("Working on Development Environment");
    Console.WriteLine("Estamos en devolopment");
}

if (app.Environment.EnvironmentName == "QA") 
{
    Log.Logger = new LoggerConfiguration()
    .WriteTo.File("C://Users//Alejandro//Documents//2024 - I//Certificacion I//PruebasGit//practiceTwo//PracticeTwo////QALog-.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();
    app.UseSwagger();
    app.UseSwaggerUI();
    Log.Information("Working on QA Environment");
    Console.WriteLine("Estamos en QA");
}

if (app.Environment.EnvironmentName == "UAT") 
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();