using Microsoft.EntityFrameworkCore;
using SimpleProductOrderApi.Data;
using SimpleProductOrderApi.Extensions;
using SimpleProductOrderApi.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddControllers(options => {
    options.Filters.Add<HttpResponseExceptionFilter>();
});

// Add EF Core with MSSQL
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("DefaultConnection not found.");;
builder.Services.AddDbContext<AppDbContext> (options => options.UseSqlServer(connectionString));

builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();