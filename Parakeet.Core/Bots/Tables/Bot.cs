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

using Npgsql;
using NpgsqlTypes;

namespace Parakeet.Core.Bots.Tables;

// UNFINISHED
[Table("bots")]
[Index(nameof(ID), IsUnique = true)]
[Index(nameof(Token), IsUnique = true)]
public class Bot {
	[Column("id")]
	public Guid ID { get; set; }

	[Column("owner")]
	public Guid OwnerID { get; set; }

	[Column("token")]
	public Guid Token { get; set; }

	[Column("public")]
	public bool IsPublic { get; set; }

	[Column("analytics")]
	public bool Analytics { get; set; }

	[Column("discoverable")]
	public bool IsDiscoverable { get; set; }

	[Column("interactions_url")]
	public required string InteractionsURL { get; set; }

	[Column("terms_of_service")]
	public required string TermsOfServiceURL { get; set; }

	[Column("privacy_policy_url")]
	public required string PrivacyPolicyURL { get; set; }

	[Column("flags")]
	public Int32? Flags { get; set; }
}