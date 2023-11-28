using EstudiantesAPP.Dominio.IRepositories;
using EstudiantesAPP.Dominio.IServices;
using EstudiantesAPP.Persistencia.Context;
using EstudiantesAPP.Persistencia.Repositories;
using EstudiantesAPP.Servicios.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AplicationDBContext>
    (option => option.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));

builder.Services.AddScoped<IEstudianteRepository, EstudianteRepository>();
builder.Services.AddScoped<IEstudianteService, EstudianteService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
