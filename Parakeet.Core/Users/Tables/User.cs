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
using System.Text.Json.Serialization;

using EntityFrameworkCore.Projectables;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Parakeet.Core.Attachments.Tables;
using Parakeet.Shared.Classes.API;

using FileData = Parakeet.Shared.Classes.API.FileData;

namespace Parakeet.Core.Users.Tables;

public enum FieldsUser {
	Avatar,
	StatusText,
	StatusPresence,
	ProfileContent,
	ProfileBackground,
	DisplayName,
	Pronouns,

	// Unternal fields
	Suspension,
	None,
}

/// User's relationship with another user (or themselves)
public enum RelationshipStatus {
	None,
	User,
	Friend,
	Outgoing,
	Incoming,
	Blocked,
	BlockedOther,
}

// Relationship entry indicating current status with other user
public struct Relationship {
	[JsonPropertyName("id")]
	public string ID { get; set; }
	[JsonPropertyName("status")]
	public RelationshipStatus Status { get; set; }
}

// Presence status
public enum Presence {
	// User is online
	Online,
	// User is not currently available
	Idle,
	// User is focusing / will only receive mentions
	Focus,
	// User is busy / will not receive any notifications
	Busy,
	// User appears to be offline
	Invisible,
}

// User's active status
public struct UserStatus {
	// Custom status text
	[JsonPropertyName("text")]
	public string? Text { get; set; }
	// Current presence option
	[JsonPropertyName("presence")]
	public Presence? Presence { get; set; }
}

// User's profile
public struct UserProfile {
	// Text content on user's profile
	[JsonPropertyName("content")]
	public string? Content { get; set; }
	/// Background visible on user's profile
	[JsonPropertyName("background")]
	public Attachment Background { get; set; }
}

public class BotInformation {
	[JsonPropertyName("owner")]
	public required string Owner { get; set; }
}

// UNFINISHED
[Table("users")]
[Index(nameof(ID), IsUnique = true)]
[Index(nameof(Username), IsUnique = true)]
public class User {
	[Column("id")]
	public Guid ID { get; set; }

	[Column("username")]
	[StringLength(160)]
	public required string Username { get; set; }

	[Column("discriminator")]
	[StringLength(4)]
	public required string Discriminator { get; set; }

	[Column("display_name")]
	[StringLength(160)]
	public string? DisplayName { get; set; }

	[Column("pronouns")]
	public List<String>? Pronouns { get; set; }

	[Column("avatar", TypeName = "jsonb")]
	public FileData? Avatar { get; set; }

	[Column("relations", TypeName = "jsonb")]
	public List<Relationship>? Relationships { get; set; }

	[Column("badges")]
	public Int32 Badges { get; set; }

	[Column("status", TypeName = "jsonb")]
	public UserStatus? Status { get; set; }

	[Column("profile", TypeName = "jsonb")]
	public UserProfile? Profile { get; set; }

	[Column("suspended_until")]
	public DateTime? SuspendedUntil { get; set; }

	[Column("flags")]
	public Int32 Flags { get; set; }

	[Column("bot", TypeName = "jsonb")]
	public BotInformation? Bot { get; set; }

	[Column("privileged")]
	public bool Privileged { get; set; }

	[Column("last_acknowledged_policy_change")]
	public DateTime LastAcknowledgedPolicyChange { get; set; }
};