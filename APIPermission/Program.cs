using APIPermission.Data.Configurations;
using APIPermission.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDatabaseConfig>(new DatabaseConfig
{
    ConnectionString = "mongodb://172.17.0.3:27017",

    DatabaseName = "APIPermission",
});

builder.Services.AddTransient<INoSQL, NoSQL>();

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