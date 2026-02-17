namespace Parakeet.Shared.Classes.API;

public enum RelationshipStatus : Byte {
	None,
	User,
	Friend,
	Outgoing,
	Incoming,
	Blocked,
	BlockedOther
}

public enum UserFlags : Byte {
	Suspended = 1,
	Deleted = 2,
	Banned = 4,
}

public enum UserBadges : UInt16 {
	Developer = 1,
	Translator = 2,
	Supporter = 4,
	ResponsibleDisclosure = 8,
	Founder = 16,
	PlatformModeration = 32,
	ActiveSupporter = 64,
	Paw = 128,
	EarlyAdopter = 256,
	ReservedRelevantJokeBadge1 = 512,
	ReservedRelevantJokeBadge2 = 1024,
}

public class User(Ulid id, string user, string discrim, string instance, string? name, string[] woke, bool on, bool priv, Ulid? owner, File avi, RelationshipStatus rel, UserBadges badges, UserFlags flags, UserStatus status) {
	public readonly Ulid UserID = id;

	/**
	<summary>
	Validate FIDs with regexp: <c>\b([a-z0-9._%+-]{1,160})@([a-z0-9-]+(\.[a-z0-9-]+)*)$</c>.<br/>
	Yes thats from the polyproto docs, no I don't care
	</summary>
	*/
	public readonly string Homeserver = instance;

	public string Username = user, Discriminator = discrim;

	public string? DisplayName = name;
	public string[]? Pronouns = woke;

	public bool Online = on;
	public bool Privileged = priv;
	
	/**
	<summary>
	The owner of the given account.<br/>
	If it's null, this is a human owned account, refer to UserID. Otherwise, it's a bot.
	</summary>
	*/
	public Ulid? BotOwner = owner;

	public File Avatar = avi;
	public RelationshipStatus Relationship = rel;

	public UserBadges Badges = badges;
	public UserFlags Flags = flags;
	public UserStatus Status = status;
}