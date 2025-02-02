using Comuclub.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// appsettings.json'dan connection string'i al
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// DbContext'i DI container'ýna ekle
builder.Services.AddDbContext<ComuClubContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Hedef API endpoint'leri buraya ekleyebilirsin
app.MapGet("/", () => "Hello World!");

app.Run();
