using Autos.Data;
using Autos.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AutosAPIDbContext>();

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

async void AddTest(DbContext db)
{
    var auto = await db.AddAsync( new Auto(){ Modelo = "Peugeot"});

    var cliente = await db.AddAsync(new Cliente() { LastName = "Caeiro", Name = "Rodrigo" });
    await db.SaveChangesAsync();

    var autoCliente = await db.AddAsync(new AutoCliente() { Patente = "ABC 040", AutoID = auto.Entity.Id, ClienteID = cliente.Entity.Id });
    await db.SaveChangesAsync();

    await db.AddAsync(new Reparacion() { Km = 2000, Trabajo = "Service", AutoClienteID = autoCliente.Entity.Id, Fecha= new DateOnly(2022, 1, 1)});
    await db.AddAsync(new Reparacion() { Km = 500, Trabajo = "adada", AutoClienteID = autoCliente.Entity.Id, Fecha= new DateOnly(2022, 1, 1)});

    await db.SaveChangesAsync();
}

using (var db = new AutosAPIDbContext())
{
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    AddTest(db);
}

app.Run();
