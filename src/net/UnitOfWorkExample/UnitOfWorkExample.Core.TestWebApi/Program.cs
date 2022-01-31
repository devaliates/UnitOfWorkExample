using Microsoft.EntityFrameworkCore;

using System.Reflection;

using UnitOfWorkExample.RepositoryLayer.Abstract;
using UnitOfWorkExample.RepositoryLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ILocalDbContext, LocalDbContext>(x => x.UseNpgsql(builder.Configuration.GetConnectionString("LocalConnection")
    ));

builder.Services.AddDbContext<IAzureDbContext, AzureDbContext>(x => x.UseNpgsql(builder.Configuration.GetConnectionString("AzureConnection")
    ));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();