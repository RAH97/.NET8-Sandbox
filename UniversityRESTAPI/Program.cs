using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using UniversityRankingAPI.Migrations;
using UniversityRankingAPI.Models.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<UniversityContext>(options => 
                             options.UseSqlServer(builder.Configuration.GetConnectionString("UniversityDataContext")));


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

await PopulateDatabase();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



 async Task PopulateDatabase()
 {
    using (var scope = app.Services.CreateScope())
    {
        var service = scope.ServiceProvider;
        var context = service.GetService<UniversityContext>();
        MockContextDataPopulator mocker = new MockContextDataPopulator(context);
        await mocker.InsertMockUniversityData();

    }
}