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
using EntityFrameworkCore.Projectables;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Parakeet.Shared.Classes.API;

using FileData = Parakeet.Shared.Classes.API.FileData;

namespace Parakeet.Core.Users.Tables;

// UNFINISHED
[Table("users")]
[Index(nameof(ID), nameof(Homeserver), IsUnique = true)]
[Index(nameof(Username), nameof(Homeserver), IsUnique = true)]
[Index(nameof(Homeserver))]
public class User {
	[Column("id")]
	public Guid ID { get; set; }

	[Column("homeserver")]
	[StringLength(512)]
	public string Homeserver { get; set; }

	[Column("username")]
	[StringLength(160)]
	public string Username { get; set; }

	[Column("avatar", TypeName = "jsonb")]
	public FileData Avatar { get; set; }
};