using dbContaApi.Servicios;
using dbContaLibrary;
using dbContaLibrary.Interfaces;
using dbContaLibrary.Servicios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NLog;
using NLog.Web;
using Oracle.ManagedDataAccess.Client;
using System.Text;


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


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {

    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    };
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
builder.Services.AddLogin();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ObtenerInformacionToken>();

builder.Logging.ClearProviders();
builder.Host.UseNLog();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(
    options =>
    {
        options.AddPolicy("AllowAngularOrigins", builder => { builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod(); });
    });


var app = builder.Build();
app.UseCors("AllowAngularOrigins");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
