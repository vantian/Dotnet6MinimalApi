using MyMicroServices.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IPcsrApiService, PcsrApiService>();

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

///Simple API
app.MapGet("/api", () => "Hello World!");

///Demo user API
app.MapPost("/api/users/sample", async (IPcsrApiService service) =>
{
    var str = await service.GetSampleUser();

    return Results.Content(str, "application/json");
});

///Demo user API (simplified)
app.MapPost("/api/users/sample/v2", async (IPcsrApiService service) => Results.Content(await service.GetSampleUser(), "application/json"));

app.Run();
