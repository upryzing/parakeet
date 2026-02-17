using IniParser;
using IniParser.Model;

namespace Parakeet.Shared.Classes;

public class InstanceConfig {
	public InstanceConfig(String path) {
		var parser = new FileIniDataParser();
		IniData data = parser.ReadFile(path);

		if (!data.Sections.ContainsSection("Instance"))
			throw new FileLoadException("Instance config file is malformed");

		APIUrl    = (data["Instance"]["APIAddress"] is not null    ? data["Instance"]["APIAddress"]    : "https://localhost:14702");
		EventsUrl = (data["Instance"]["EventAddress"] is not null  ? data["Instance"]["EventAddress"]  : "https://localhost:14703");
		DoveUrl   = (data["Instance"]["DoveAddress"] is not null   ? data["Instance"]["DoveAddress"]   : "https://localhost:14704");
		PigeonUrl = (data["Instance"]["PigeonAddress"] is not null ? data["Instance"]["PigeonAddress"] : "https://localhost:14705");
		bool.TryParse(data["Instance"]["InviteOnly"], out InviteOnly);
	}

	public readonly String APIUrl;
	public readonly String EventsUrl;
	public readonly String DoveUrl;
	public readonly String PigeonUrl;

	public readonly bool InviteOnly;
}