using dbContaLibrary;
using dbContaLibrary.Interfaces;
using dbContaLibrary.Servicios;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
       .SetBasePath(builder.Environment.ContentRootPath)
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);


builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

// Add services to the container.
var configuration = builder.Configuration;
//builder.Services.AddControllers();
builder.Services.AddAntiforgery();
builder.Services.AddAPPConfiguration(configuration);
builder.Services.AddTipoLibro();
builder.Services.AddTipoDocumento();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
