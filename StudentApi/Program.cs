using StudentApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//  TESTING StudentAPI DT:250323@10:12am
// Console.WriteLine("Hello World!");
// Console.ReadLine();

// Set the app to listen on all IPs and port 8080 (required for OpenShift)
// builder.WebHost.UseUrls("http://0.0.0.0:8080");

// testing push and pull 2025/03/09 2:56pm

// Register the StudentContext with the connection string
builder.Services.AddDbContext<StudentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Swagger is already configured by default
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
