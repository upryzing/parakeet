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

// UNFINISHED
[Table("channel_invites")]
[Index(nameof(Code), IsUnique = true)]
public class ChannelInvite {
	[Column("code")]
	public Guid Code { get; set; }

	[Column("creator")]
	public Guid Creator { get; set; }

	[Column("server")]
	public Guid ServerID { get; set; }

	[Column("channel")]
	public Guid ChannelID { get; set; }
};