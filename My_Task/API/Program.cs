using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Configure SQLite DbContext
var connectionString = builder.Configuration.GetConnectionString("YourConnectionStringName");
builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlite(connectionString));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DataContext>();
    await SeedData.seed(context); // Ensure this is awaited
}
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DataContext>();
    await SeedData2.seed(context); // Ensure this is awaited
}

app.Run();