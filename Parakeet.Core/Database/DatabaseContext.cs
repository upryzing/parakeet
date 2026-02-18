using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.Projectables;
using EntityFrameworkCore.Projectables.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Npgsql;

using Parakeet.Shared.Classes;
using Parakeet.Shared.Classes.Configuration;

namespace Parakeet.Core.Database;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options) {
	public virtual DbSet<User> Users { get; init; } = null!;

	public static NpgsqlDataSource GetDataSource(InstanceConfig.DatabaseSection config) {
		var dataSourceBuilder = new NpgsqlDataSourceBuilder {
			ConnectionStringBuilder = {
				Host            = config.DatabaseUrl,
				Port            = (int)config.DatabasePort,
				Username        = config.DatabaseUser,
				Password        = config.DatabasePassword,
				Database        = config.Database,
				MaxPoolSize     = (int)config.MaximumPoolSize,
				ApplicationName = "Parakeet.Core",
			}
		};

		Console.WriteLine(config.DatabaseUrl, config.Database);

		return ConfigureDataSource(dataSourceBuilder, config);
	}

	private static NpgsqlDataSource ConfigureDataSource(NpgsqlDataSourceBuilder dataSourceBuilder, InstanceConfig.DatabaseSection config) {
		dataSourceBuilder.EnableDynamicJson();

		dataSourceBuilder.EnableParameterLogging();

		return dataSourceBuilder.Build();

	}

	public static void Configure(DbContextOptionsBuilder optionsBuilder, NpgsqlDataSource dataSource, InstanceConfig.DatabaseSection config) {
		optionsBuilder.UseNpgsql(dataSource, options => {});

		optionsBuilder.UseProjectables(options => options.CompatibilityMode(CompatibilityMode.Full));
	}

}