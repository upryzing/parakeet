using Microsoft.EntityFrameworkCore;

using Parakeet.Core.Database;

using Parakeet.Shared.Classes.Configuration;

InstanceConfig.MakeStaticConfig("instance.conf");

var conf = InstanceConfig.StaticConf ?? throw new NullReferenceException("Couldn't make config file, whoopsies!");

var builder = WebApplication.CreateBuilder(args);

var dataSource = DatabaseContext.GetDataSource(conf.Database);
builder.Services.AddDbContext<DatabaseContext>(options => { DatabaseContext.Configure(options, dataSource, conf.Database); });

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