namespace Parakeet.Shared.Classes.API;

public class UserProfile(String? content, File? bannerFile, String? tz) {
	public readonly String? Contents = content;
	public readonly File? Banner = bannerFile;

	public readonly String? Timezone = tz;
}