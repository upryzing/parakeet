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

using Npgsql;
using NpgsqlTypes;

namespace Parakeet.Core.Accounts.Tables;

// Local registered users
[Table("accounts")]
[Index(nameof(ID), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
[Index(nameof(Password))]
[Index(nameof(Deletion))]
public class Account {
	[Column("id")]
	public Guid ID { get; set; }

	[Column("email")]
	public string Email { get; set; }

	[Column("password")]
	[StringLength(105)]
	public string Password { get; set; }

	[Column("deletion")]
	public bool Deletion { get; set; }
};
