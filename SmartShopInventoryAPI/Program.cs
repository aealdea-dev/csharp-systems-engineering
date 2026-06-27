using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Database Connection
builder.Services.AddDbContext<SmartShopInventoryAPI.Data.SmartShopDbContext>(options =>
    options.UseSqlite("Data Source=smartshop.db"));

// 2. Add Controllers
builder.Services.AddControllers();

// 3. Add Swagger (The Visual Control Panel)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 4. Turn on the Swagger UI if we are testing
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();