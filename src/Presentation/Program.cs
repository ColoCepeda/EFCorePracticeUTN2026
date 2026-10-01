using GestionProductos.Application.Interfaces;
using GestionProductos.Infrastructure.Persistence;
using GestionProductos.Infrastructure.Repositories;
using GestionProductos.Presentation.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Base de datos
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Repositorios
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// [CLASE JWT] Paso 5: registrar ICustomAuthenticationService

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // [CLASE JWT] Paso 6: botón Authorize en Swagger

// [CLASE JWT] Paso 5: AddAuthentication().AddJwtBearer()

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// [CLASE JWT] Paso 5: app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
