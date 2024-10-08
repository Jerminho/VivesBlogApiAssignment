using Microsoft.EntityFrameworkCore;
using VivesBlog.Core;
using VivesBlog.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add DbContext and In-Memory Database (can be switched to SQL Server or another provider in production)
builder.Services.AddDbContext<VivesBlogDbContext>(options =>
{
    options.UseInMemoryDatabase(nameof(VivesBlogDbContext));  // In-memory for development/testing
});

// Add scoped services for DI (Dependency Injection)
builder.Services.AddScoped<ArticleService>();
builder.Services.AddScoped<PersonService>();

// Add Swagger for API documentation (useful for testing your API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Optional: Configure CORS if you want the API to be accessible from different domains (frontend apps)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin()  // You can configure specific origins in production
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    using var scope = app.Services.CreateScope();
    var database = scope.ServiceProvider.GetRequiredService<VivesBlogDbContext>();
    database.Seed(); // Seed initial data for testing/development
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

// If CORS is configured, add it here
app.UseCors();

app.UseAuthorization();

app.MapControllers();  // Map API controllers

app.Run();