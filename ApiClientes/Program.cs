using Microsoft.EntityFrameworkCore;
using ApiClientes.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuración de la base de datos PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DATABASE_URL")));

// Agregar servicios al contenedor.
builder.Services.AddControllers();

// Configuración para Swagger (opcional)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración para Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configuración de la pipeline HTTP
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
