using Microsoft.EntityFrameworkCore;
using WebAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database Connection
string connString = builder.Configuration.GetConnectionString("DefaultConnection");
try
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseMySql(connString, new MySqlServerVersion(new Version(8, 0, 26)), mySqlOptions =>
        {
            mySqlOptions.EnableRetryOnFailure();
        });
    });
}
catch (Exception ex)
{
    // Log and handle the exception as needed.
    Console.WriteLine("Error configuring the database context: " + ex.Message);
    throw new Exception("Error configuring the database context: " + ex.Message, ex);
}

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

app.Run("https://localhost:5001");
