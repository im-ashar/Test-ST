using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Test_ST.Data;
using Test_ST.ExceptionHandling;
using Test_ST.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'AppDbContextConnection' not found.");

builder.Services.AddDbContextFactory<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddScoped<ISeedDataService, SeedDataService>();
builder.Services.AddScoped<IFormService, FormService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();

var app = builder.Build();
await SeedAsync(app.Services);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



static async Task SeedAsync(IServiceProvider services)
{
    var scope = services.CreateScope();
    var seedDataService = scope.ServiceProvider.GetRequiredService<ISeedDataService>();
    await seedDataService.SeedDataAsync();
}