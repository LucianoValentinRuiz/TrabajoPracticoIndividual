using Infraestructure.Command;
using Aplication.Interface;
using Aplication.Interface_Service;
using Infraestructure.Querys;
using Aplication.Service;
using Microsoft.EntityFrameworkCore;
using TrabajoPractico;
using Infrastructure.Querys;
using Aplication.Interface_Validation;
using Presentation.Validation;
using Aplication.Interface_Mappers;
using Aplication.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyectar dependencia
var conectionString = builder.Configuration["ConnectionString"];
builder.Services.AddDbContext<CineDBContext>(options => options.UseSqlServer(conectionString));

builder.Services.AddTransient<IFuncionesService, FuncionesService>();
builder.Services.AddTransient<IFuncionesQuerys, FuncionesQuerys>();
builder.Services.AddTransient<IFuncionesCommand, FuncionesCommand>();

builder.Services.AddTransient<IPeliculasService, PeliculasService>();
builder.Services.AddTransient<IPeliculasQuerys, PeliculasQuerys>();
builder.Services.AddTransient<IPeliculasCommand, PeliculasCommand>();

builder.Services.AddTransient<IGenerosService, GenerosService>();
builder.Services.AddTransient<IGenerosQuerys, GenerosQuerys>();
builder.Services.AddTransient<IGenerosCommand, GenerosCommand>();

builder.Services.AddTransient<ISalasService, SalasService>();
builder.Services.AddTransient<ISalasQuerys, SalasQuerys>();
builder.Services.AddTransient<ISalasCommand, SalasCommand>();

builder.Services.AddTransient<ITicketsService, TicketsService>();
builder.Services.AddTransient<ITicketsQuerys, TicketsQuerys>();
builder.Services.AddTransient<ITicketsCommand, TicketsCommand>();

builder.Services.AddTransient<IFIltrosService, FiltrosService>();
builder.Services.AddTransient<IFiltrosQuerys, FiltrosQuerys>();

builder.Services.AddTransient<IValidationDatetime, ValidationDatetime>();

builder.Services.AddTransient<IFuncionMapper, FuncionMapper>();
builder.Services.AddTransient<IPeliculaMapper, PeliculaMapper>();
builder.Services.AddTransient<ITicketMapper,TicketMapper>();
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
