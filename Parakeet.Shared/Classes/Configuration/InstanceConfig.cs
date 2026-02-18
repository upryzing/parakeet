using System.ComponentModel.DataAnnotations;


using IniParser;
using IniParser.Model;

namespace Parakeet.Shared.Classes.Configuration;

public sealed class InstanceConfig {
	public InstanceConfig(String path) {
		var parser = new FileIniDataParser();
		IniData data = parser.ReadFile(path);

		if (!data.Sections.ContainsSection("Instance"))
			throw new FileLoadException("Instance config file is malformed");

		if (!data.Sections.ContainsSection("Database"))
			throw new FileLoadException("Instance config file is malformed");

		Instance = new InstanceSection {
			APIUrl = (data["Instance"]["APIAddress"] is not null ? data["Instance"]["APIAddress"] : "http://localhost:14702"),
			EventsUrl = (data["Instance"]["EventAddress"] is not null ? data["Instance"]["EventAddress"] : "http://localhost:14703"),
			DoveUrl = (data["Instance"]["DoveAddress"] is not null ? data["Instance"]["DoveAddress"] : "http://localhost:14704"),
			PigeonUrl = (data["Instance"]["PigeonAddress"] is not null ? data["Instance"]["PigeonAddress"] : "http://localhost:14705")
		};

		bool.TryParse(data["Instance"]["InviteOnly"], out Instance.InviteOnly);

		Database = new DatabaseSection {
			DatabaseUrl = (data["Database"]["DatabaseURL"] is not null ? data["Database"]["DatabaseURL"] : "localhost"),
			DatabaseUser = (data["Database"]["DatabaseUser"] is not null ? data["Database"]["DatabaseUser"] : "parakeet"),
			DatabasePassword = (data["Database"]["DatabasePassword"] is not null ? data["Database"]["DatabasePassword"] : "parakeet"),
			Database = (data["Database"]["Database"] is not null ? data["Database"]["Database"] : "parakeet"),
		};

		uint.TryParse(data["Database"]["Port"], System.Globalization.NumberStyles.Integer, null, out Database.DatabasePort);
		uint.TryParse(data["Database"]["MaximumPoolSize"], System.Globalization.NumberStyles.Integer, null, out Database.MaximumPoolSize);

		if (Database.DatabasePort == 0)
			Database.DatabasePort = 5432;

		if (Database.MaximumPoolSize == 0)
			Database.MaximumPoolSize = 10;
	}

	/// Lexi, please don't smite me
	public static void MakeStaticConfig(string path) {
		StaticConf = new InstanceConfig(path);
	}

	public sealed class InstanceSection {
		public required String APIUrl;
		public required String EventsUrl;
		public required String DoveUrl;
		public required String PigeonUrl;

		public bool InviteOnly;
	}

	public sealed class DatabaseSection {
		public required String DatabaseUrl;
		public uint DatabasePort;
		public required String DatabaseUser;
		public required String DatabasePassword;
		public required String Database;

		public uint MaximumPoolSize;
	}

	public static InstanceConfig? StaticConf;

	public InstanceSection Instance;
	public DatabaseSection Database;
}