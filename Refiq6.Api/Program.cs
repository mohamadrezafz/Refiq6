using Refiq6.Api.Middleware;
using Refiq6.Application.Interfaces.Caching;
using Refiq6.Infrastructure;
using Refiq6.Infrastructure.Persistance;
using Refiq6.Infrastructure.Services.Caching;
using Refiq6.Application;
using Refiq6.Application.Interfaces.Service;
using Refiq6.Application.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;
builder.Services.AddInfrastructureServices(configuration);
builder.Services.AddApplicationServices();


builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<ICacheProvider, MemoryCacheProvider>();

builder.Services.AddScoped<IQuizService, QuizService>();

builder.Services.AddMemoryCache();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Refiq6 APIs Version 1");
    });

    // Initialize and seed database
    using var scope = app.Services.CreateScope();
    var dbInitialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();
    await dbInitialiser.InitialiseAsync();
}
app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

//app.UseAuthorization();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapControllers();

app.Run();
