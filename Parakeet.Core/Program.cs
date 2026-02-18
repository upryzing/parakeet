/**
<copyright>
Parakeet (Upryzing C# Instance Server)
Copyright (C) 2026 Upryzing

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
GNU Affero General Public License for more details.

You should have received a copy of the GNU Affero General Public License
along with this program. If not, see <https://www.gnu.org/licenses/>.
</copyright>
*/

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