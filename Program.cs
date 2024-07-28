using HealthCareApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<HealthCareContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HealthCareDatabase")));

var app = builder.Build();
var connectionString = builder.Configuration.GetConnectionString("HealthCareDatabase");
Console.WriteLine($"Connection String: {connectionString}");

builder.Services.AddDbContext<HealthCareContext>(options =>
    options.UseSqlServer(connectionString));


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
