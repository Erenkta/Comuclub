using Comuclub.Data;
using Comuclub.Service.Abstracts;
using Comuclub.Service.Concretes;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IClubService, ClubService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IOrganizerService, OrganizerService>();

// appsettings.json'dan connection string'i al
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// DbContext'i DI container'ýna ekle
builder.Services.AddDbContext<ComuClubContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Comu Club");
        c.RoutePrefix = string.Empty; // Varsayýlan route'u Swagger UI'ye yönlendir
    });

}
app.UseRouting();
app.UseAuthorization();
app.MapControllers();  

// Hedef API endpoint'leri buraya ekleyebilirsin
app.MapGet("/", () => "Hello World!");


app.Run();
