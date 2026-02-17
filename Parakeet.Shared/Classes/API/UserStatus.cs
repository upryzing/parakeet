namespace Parakeet.Shared.Classes.API;

public enum UserPresence {
	Online,
	Idle,
	Focus,
	Busy,
	Invisible
}

public class UserStatus(string txt, UserPresence presence) {
	public string Text = txt;
	public UserPresence Presence = presence;
}