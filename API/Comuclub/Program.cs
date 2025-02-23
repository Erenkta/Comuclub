using Comuclub.Common;
using Comuclub.Data;
using Comuclub.Service.Abstracts;
using Comuclub.Service.Concretes;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IClubService, ClubService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IOrganizerService, OrganizerService>();
builder.Services.AddScoped<ILog,Logger>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


// appsettings.json'dan connection string'i al
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// DbContext'i DI container'ýna ekle
builder.Services.AddDbContext<ComuClubContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter()); // ENUMLARIN Default olarak string sayýlmasý için.
    });


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



app.Run();
