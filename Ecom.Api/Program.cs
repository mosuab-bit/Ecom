using Ecom.Infrustructure;
using Ecom.Api.Mapping;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var webRootPath = builder.Environment.WebRootPath
    ?? Path.Combine(builder.Environment.ContentRootPath, "wwwroot");
Directory.CreateDirectory(webRootPath);
//builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(webRootPath));
builder.Services.infrastructureConfiguration(builder.Configuration);
builder.Services.AddAutoMapper(cfg => { }, typeof(CategoryMapping).Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
