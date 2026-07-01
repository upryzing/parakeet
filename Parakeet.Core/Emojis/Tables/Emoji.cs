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

namespace Parakeet.Core.Emojis.Tables;

public enum EmojiParentType : ushort {
	Server,
	Detached
}

public class EmojiParent {
	[JsonPropertyName("parent_type")]
	public EmojiParentType Type { get; set; }

	[JsonPropertyName("id")]
	public string? ID { get; set; }
}

// UNFINISHED
[Table("emojis")]
[Index(nameof(ID), IsUnique = true)]
public class Emoji {
	[Column("id")]
	[Required]
	public Guid ID { get; set; }

	[Column("parent", TypeName = "jsonb")]
	public required EmojiParent Parent { get; set; }

	[Column("creator_id")]
	public Guid CreatorID { get; set; }

	[Column("name")]
	public required string Name { get; set; }

	[Column("animated")]
	public bool IsAnimated { get; set; }

	[Column("nsfw")]
	public bool IsNSFW { get; set; }
};