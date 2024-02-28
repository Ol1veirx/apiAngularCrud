using apiAngularCrud.Data;
using apiAngularCrud.Repositories;
using apiAngularCrud.Repositories.IRepositories;
using apiAngularCrud.Services;
using apiAngularCrud.Services.IServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddCors();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<APIContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("APIConnction");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
builder.Services.AddScoped<IPersonServices, PersonService>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
