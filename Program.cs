using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Services;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RadioStationDbContext>(options =>
    options.UseSqlite("Data Source=radio.db"));

builder.Services.AddScoped<AiMusicService>();

// CORS (important for frontend)
builder.Services.AddCors(options =>
{
    options.AddPolicy("frontend",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("frontend");

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
