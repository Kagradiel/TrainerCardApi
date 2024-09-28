using Microsoft.EntityFrameworkCore;
using TrainerCardBackEnd.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TrainerDataContext>(Options =>
    Options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();


    app.MapGet("/", () => Results.Redirect("/swagger/index.html"));
}
else
{
    app.MapGet("/", () => "Hello World!");
}
app.Run();
