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

using System.Text.Json.Serialization;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using EntityFrameworkCore.Projectables;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parakeet.Shared.Classes.API;
using Parakeet.Core.Attachments.Tables;

namespace Parakeet.Core.Spaces.Tables;

public class Category {
	[JsonPropertyName("id")]
	public Guid ID;

	[JsonPropertyName("title")]
	[StringLength(32)]
	public string Title;

	[JsonPropertyName("channels")]
	public string[] Channels;
}

public class SystemMessageChannels {
	[JsonPropertyName("user_joined")]
	public string? UserJoined;

	[JsonPropertyName("user_left")]
	public string? UserLeft;

	[JsonPropertyName("user_kicked")]
	public string? UserKicked;

	[JsonPropertyName("user_banned")]
	public string? UserBanned;
}

public class OverrideField {
	[JsonPropertyName("a")]
	public Int64 Allow;

	[JsonPropertyName("d")]
	public Int64 Disallow;
}

public class Role {
	[JsonPropertyName("id")]
	public string? ID;

	[JsonPropertyName("name")]
	public string? Name;

	[JsonPropertyName("permissions")]
	public required OverrideField Permissions { get; set; }

	[JsonPropertyName("colour")]
	public string? Colour;

	[JsonPropertyName("hoist")]
	public bool Hoist;

	[JsonPropertyName("rank")]
	public Int64 Rank;
}

// UNFINISHED
[Table("spaces")]
[Index(nameof(ID), IsUnique = true)]
[Index(nameof(OwnerID))]
public class Space {
	[Column("id")]
	public Guid ID { get; set; }

	[Column("owner")]
	public Guid OwnerID { get; set; }

	[Column("name")]
	[StringLength(32)]
	public required string ServerName { get; set; }

	[Column("description")]
	[StringLength(32)]
	public string? ServerDescription { get; set; }

	[Column("nsfw")]
	[DefaultValue(false)]
	public bool IsNSFW { get; set; }

	[Column("roles")]
	public Dictionary<String, Role> Roles { get; set; } = [];

	[Column("default_permissions")]
	public Int64 DefaultPerssions { get; set; }

	[Column("icon", TypeName = "jsonb")]
	public Attachment? Icon { get; set; }

	[Column("banner", TypeName = "jsonb")]
	public Attachment? Banner { get; set; }

	[Column("channels")]
	public List<string> Channels { get; set; }

	[Column("categories", TypeName = "jsonb")]
	public List<Category>? Categories { get; set; }

	[Column("system_messages", TypeName = "jsonb")]
	public SystemMessageChannels? SystemMessages { get; set; }
};