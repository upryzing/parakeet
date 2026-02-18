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

// Do we actually need all of this for the backend?
public class User(Ulid userID, string username, string userDiscriminator, string userInstance, string? displayName, string[] pronounList, bool isOnline, bool hasPrivileges, Ulid? botOwner, File avatar, RelationshipStatus relationships, UserBadges badges, UserFlags userFlags, UserStatus status) {
	public readonly Ulid UserID = userID;

	/**
	<summary>
	Validate FIDs with regexp: <c>\b([a-z0-9._%+-]{1,160})@([a-z0-9-]+(\.[a-z0-9-]+)*)$</c>.<br/>
	Yes, that is from the polyproto docs and no I don't care.
	</summary>
	*/
	public readonly string Homeserver = userInstance;

	public string Username = username, Discriminator = userDiscriminator;

	public string? DisplayName = displayName;
	public string[]? Pronouns = pronounList;

	public bool Online = isOnline;
	public bool Privileged = hasPrivileges;
	
	/**
	<summary>
	The owner of the given account.<br/>
	If it's null, this is a human owned account, refer to UserID. Otherwise, it's a bot.
	</summary>
	*/
	public Ulid? BotOwner = botOwner;

	public File Avatar = avatar;
	public RelationshipStatus Relationship = relationships;

	public UserBadges Badges = badges;
	public UserFlags Flags = userFlags;
	public UserStatus Status = status;
}