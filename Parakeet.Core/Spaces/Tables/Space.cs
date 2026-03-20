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

[ComplexType]
public class Category {
	public Guid ID;

	[StringLength(32)]
	public string Title;

	public string[] Channels;
}

// UNFINISHED
[Table("spaces")]
[Index(nameof(ID), nameof(Homeserver), IsUnique = true)]
[Index(nameof(OwnerID))]
[Index(nameof(Homeserver))]
public class Space {
	[Column("id")]
	public Guid ID { get; set; }

	[Column("ownerID")]
	public Guid OwnerID { get; set; }

	[Column("homeserver")]
	public string Homeserver { get; set; }

	[Column("serverName")]
	[StringLength(32)]
	public string ServerName { get; set; }

	[Column("serverDesc")]
	[StringLength(32)]
	public string ServerDescription { get; set; }

	[Column("nsfw")]
	[DefaultValue(false)]
	public bool IsNSFW { get; set; }

	[Column("defaultPermissions")]
	public long DefaultPerssions { get; set; }

	[Column("channels")]
	public List<string> Channels { get; set; }

	[Column("categories", TypeName = "jsonb")]
	public List<Category> Categories { get; set; }
};