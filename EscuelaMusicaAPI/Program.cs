using EscuelaMusicaAPI.Data;
using EscuelaMusicaAPI.Repositories;
using EscuelaMusicaAPI.Repositories.Interfaces;
using EscuelaMusicaAPI.Services;
using EscuelaMusicaAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();

builder.Services.AddTransient<IEscuelaRepository, EscuelaRepository>();
builder.Services.AddTransient<IEscuelaService, EscuelaService>();

builder.Services.AddTransient<IAlumnoRepository, AlumnoRepository>();
builder.Services.AddTransient<IAlumnoService, AlumnoService>();

builder.Services.AddTransient<IProfesorRepository, ProfesorRepository>();
builder.Services.AddTransient<IProfesorService, ProfesorService>();

builder.Services.AddTransient<IAlumnoProfesorRepository, AlumnoProfesorRepository>();
builder.Services.AddTransient<IAlumnoProfesorService, AlumnoProfesorService>();

var app = builder.Build();

app.MapControllers();

app.Run();
