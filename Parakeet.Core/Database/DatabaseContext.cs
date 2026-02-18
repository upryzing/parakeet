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

	/**
	<summary>
	Sets up the connection string.
	</summary>
	*/
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

		return ConfigureDataSource(dataSourceBuilder, config);
	}

	/**
	<summary>
	Build the data source with some additional configuring.
	</summary>
	*/
	private static NpgsqlDataSource ConfigureDataSource(NpgsqlDataSourceBuilder dataSourceBuilder, InstanceConfig.DatabaseSection config) {
		dataSourceBuilder.EnableDynamicJson();

		dataSourceBuilder.EnableParameterLogging();

		return dataSourceBuilder.Build();
	}

	/**
	<summary>
	Adds some additional options onto optionsBuilder. Add more in the future?
	</summary>
	*/
	public static void Configure(DbContextOptionsBuilder optionsBuilder, NpgsqlDataSource dataSource, InstanceConfig.DatabaseSection config) {
		optionsBuilder.UseNpgsql(dataSource, options => {});

		optionsBuilder.UseProjectables(options => options.CompatibilityMode(CompatibilityMode.Full));
	}

}