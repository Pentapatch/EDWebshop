using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Cross-Origin Resource Sharing (CORS) config
builder.Services.AddCors(options =>
    options.AddPolicy("AllowAllPolicy",
        policy =>
        {
            var allowedHosts = builder.Configuration.GetValue<string>("AllowedHosts")!;
            policy.WithOrigins(allowedHosts)
            .AllowAnyMethod()
            .AllowAnyHeader();
        }));

// Configure database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite(connectionString);
});

// Dependency Injection
// TODO: DI repository

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