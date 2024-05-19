using EcoVitalAPI.Models;
using Microsoft.EntityFrameworkCore;
using EcoVitalAPI.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions
   .PropertyNamingPolicy = null;
});
builder.Services.AddEndpointsApiExplorer(); // Esta l�nea es necesaria para que funcione Swagger en .NET 6 que es la versi�n que estamos utilizando
builder.Services.AddSwaggerGen(); // Pero en lugar de Swagger, podr�amos usar otro generador de documentaci�n de API, como NSwag, por ejemplo
    // No obstante, Swagger es el m�s popular y el que m�s se utiliza en la industria
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials().Build());
});
var app = builder.Build();

// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
