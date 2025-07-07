using GerenciadorUsuarios.Dominio.Interfaces;
using GerenciadorUsuarios.Infraestrutura.Contextos;
using GerenciadorUsuarios.Infraestrutura.Entity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configurar o banco de dados
builder.Services.AddDbContext<Contexto>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")),
ServiceLifetime.Transient, ServiceLifetime.Transient);

// Configuração do UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnityOfWork>();

//Configurando Mediator
builder.Services.AddMediatR(x =>
{
    x.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
    x.Lifetime = ServiceLifetime.Transient;
});

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
