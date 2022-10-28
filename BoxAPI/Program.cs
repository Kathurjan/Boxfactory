using Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BoxDbContext>(options => options.UseSqlite(
    "Data source = db.db"
    
    ));
builder.Services.AddScoped<BoxesRepository>();/*
builder.Services.AddCors(options => options.AddPolicy("default", policy =>
{
    policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
        policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
        policy.WithOrigins("http://localhost:5001").AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();


}));*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
  

}

app.UseCors(p =>
{
    p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
});

//app.UseAuthorization();

app.MapControllers();

app.Run();