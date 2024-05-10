using Mc2.CrudTest.Datalayer.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Context
builder.Services.AddDbContext<CrudTestContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr"), providerOptions => providerOptions.EnableRetryOnFailure()));
#endregion


#region IoC
Mc2CrudTest.Application.StartUp.Start(builder.Services);
#endregion
#region Mediator
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Mc2CrudTest.Application.StartUp).Assembly));

#endregion

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
