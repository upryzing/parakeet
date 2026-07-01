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
using Parakeet.Core.Users.Tables;

namespace Parakeet.Core.Messages.Tables;

public enum SystemMessageType {
	Text,
	UserAdded,
	UserRemoved,
	UserJoined,
	UserLeft,
	UserKicked,
	UserBanned,
	ChannelRenamed,
	ChannelDescriptionChanged,
	ChannelIconChanged,
	ChannelOwnershipChanged,
	MessagePinned,
	MessageUnpinned
}

public class SystemMessage {
	public Guid? ID { get; set; }
	public string? Name { get; set; }
	public string? Content { get; set; }
	public string? By { get; set; }
	public string? From { get; set; }
	public DateTime? FinishedAt { get; set; }
}

// UNFINISHED
[Table("messages")]
[Index(nameof(ID), IsUnique = true)]
public class Message {
	[Column("id")]
	public Guid ID { get; set; }

	[Column("channel")]
	public Guid ChannelID { get; set; }

	[Column("author")]
	public Guid AuthorID { get; set; }

	/**
	<summary>
	The mask associated with the message. Clients should check if AuthorID and MasqueradeID are the same when grouping.<br/>
	REVOLT/STOAT: replace with masquerade object when sending to client
	</summary>
	*/
	[Column("masquerade_id")]
	public Guid? MasqueradeID { get; set; }

	/**
	<summary>
	The reactions, stored in a Dict with emoji ID as the key and a list of user IDs as the value
	</summary>
	*/
	[Column("reactions")]
	public required Dictionary<Guid, List<Guid>> Reactions { get; set; }

	[Column("pinned")]
	public bool IsPinned { get; set; }

	[Column("flags")]
	public Int32? Flags { get; set; }
};