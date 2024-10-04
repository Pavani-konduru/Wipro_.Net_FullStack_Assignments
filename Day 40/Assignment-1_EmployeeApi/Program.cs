using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure CORS to allow all origins, methods, and headers
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                         .AllowAnyMethod()
                         .AllowAnyHeader());
});

// Connect to SQL Server using Entity Framework Core
builder.Services.AddDbContext<EmployeeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Connect to SQL Server

// Add Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable CORS
app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins"); // Enable CORS policy
app.UseAuthorization();
app.MapControllers();

app.Run();
