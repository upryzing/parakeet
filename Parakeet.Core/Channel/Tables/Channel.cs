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
using Parakeet.Core.Spaces.Tables;

namespace Parakeet.Core.Channel.Tables;

public enum ChannelType : byte {
	SavedMessages,
	DirectMessage,
	Group,
	TextChannel
}

public class VoiceInformation {
	public Int64? Size { get; set; }
}

// UNFINISHED
[Table("channels")]
[Index(nameof(ID), IsUnique = true)]
public class Channel {
	[Column("id")]
	[Required]
	public Guid ID { get; set; }

	[Column("type")]
	[Required]
	public ChannelType Type { get; set; }

	[Column("name")]
	public string? Name { get; set; }

	[Column("owner")]
	public Guid? Owner { get; set; }

	[Column("description")]
	public string? Description { get; set; }

	[Column("server")]
	public List<Guid>? Recipients { get; set; }

	[Column("icon_id")]
	public Guid? IconID { get; set; }

	[Column("last_message_id")]
	public Guid? LastMessageID { get; set; }

	[Column("permissions")]
	public Int64? Permissions { get; set; }

	[Column("nsfw")]
	public bool? IsNSFW { get; set; }

	[Column("default_permissions", TypeName = "jsonb")]
	public OverrideField? DefaultPermissions { get; set; }

	[Column("role_permissions", TypeName = "jsonb")]
	public Dictionary<string, OverrideField>? RolePermissions { get; set; }
};