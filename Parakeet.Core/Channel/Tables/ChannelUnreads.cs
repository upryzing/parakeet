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

namespace Parakeet.Core.Channel.Tables;

public class ChannelCompositeKey {
	[JsonPropertyName("channel")]
	public Guid Channel;

	[JsonPropertyName("user")]
	public Guid User;
}

// UNFINISHED
[Table("channel_unreads")]
[Index(nameof(ID), IsUnique = true)]
public class ChannelUnread {
	[Column("id", TypeName = "jsonb")]
	public ChannelCompositeKey ID { get; set; }

	[Column("last_id")]
	public Guid? LastID { get; set; }

	[Column("mentions")]
	public List<Guid>? Mentions { get; set; }
};