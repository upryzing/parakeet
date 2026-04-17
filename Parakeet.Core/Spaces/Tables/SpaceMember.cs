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

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.Projectables;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Parakeet.Core.Spaces.Tables;

// UNFINISHED
[Table("space_members")]
[Index(nameof(ID), IsUnique = true)]
public class SpaceMember {
	[Column("id")]
	public Guid ID { get; set; }
	[Column("nickname")]
	[StringLength(128)]
	public string? Nickname { get; set; }

	[Column("joined_at")]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public DateTime JoinedAt { get; set; }

	[Column("roles")]
	public List<String> Roles { get; set; }

	[Column("timeout")]
	public DateTime? Timeout { get; set; }

	[Column("can_publish")]
	public DateTime? CanPublish { get; set; }

	[Column("can_receive")]
	public DateTime? CanReceive { get; set; }
};