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
builder.Services.AddTipoArticulo();
builder.Services.AddArticulo();
builder.Services.AddCatDocumento();
builder.Services.AddEmpresa();
builder.Services.AddDocumento();
builder.Services.AddDtDetalle();
builder.Services.AddGenTipoLibro();
builder.Services.AddLibroDetalle();
builder.Services.AddLibro();
builder.Services.AddUsuario();
builder.Services.AddRoles();
builder.Services.AddRolUsuario();

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
