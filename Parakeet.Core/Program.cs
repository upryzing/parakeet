using Parakeet.Core.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

var app = builder.Build();

if (app is null) {
	Console.WriteLine("Failed to build WebApplication app");
	Environment.Exit(127);
}

if (!app.Environment.IsDevelopment())
	app.UseHttpsRedirection();
else
	app.UseDeveloperExceptionPage();

app.UseRouting();
app.UseCors();
app.UseAuthentication();

app.MapOpenApi();

app.MapControllers();

await app.StartAsync();
await app.WaitForShutdownAsync();