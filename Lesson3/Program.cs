using Lesson3.DbContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
const string AllowedOrigins = "ClientApp";

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options => options
                    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(o =>
    o.AddPolicy(AllowedOrigins, builder =>
    {
        builder
        .AllowAnyOrigin()
        .AllowAnyMethod().AllowAnyHeader();
    }
    ));

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

app.UseHttpsRedirection();

app.UseCors(AllowedOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
