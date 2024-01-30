using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Zooflix.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ZooflixContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ZooflixContext") ?? throw new InvalidOperationException("Connection string 'ZooflixContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
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

// ajout pour cr�ation bdd
#pragma warning disable CS8602 // D�r�f�rencement d'une �ventuelle r�f�rence null.
using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
#pragma warning restore CS8602 // D�r�f�rencement d'une �ventuelle r�f�rence null.
{
    var context = serviceScope.ServiceProvider.GetRequiredService<ZooflixContext>();
    //context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
}

app.Run();
