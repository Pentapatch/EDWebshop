using Infrastructure.Context;
using Infrastructure.Seeding;
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
builder.Services.AddScoped<FlowerProductSeeder, FlowerProductSeeder>();

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

// Migrate the database
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync();

    // Seed some initial products
    var productSeeder = services.GetRequiredService<FlowerProductSeeder>();
    await productSeeder.Seed();
}
catch (Exception ex)
{
    // TODO: Log the exception using a logger
    Console.WriteLine(ex.Message);
}

app.Run();