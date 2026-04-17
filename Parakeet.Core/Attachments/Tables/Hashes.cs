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

using Parakeet.Shared.Classes.API;

namespace Parakeet.Core.Attachments.Tables;

// Local registered users
[Table("file_hashes")]
[Index(nameof(ID), IsUnique = true)]
public class Hashes {
	[Column("id")]
	public Guid ID { get; set; }

	/**
	<summary>
	A SHA512 hash, as a string ()
	</summary>
	*/
	[Column("processed_hash")]
	public required string ProcessedHash { get; set; }

	[Column("created_at")]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public DateTime UploadedAt { get; set; }

	[Column("bucket_id")]
	public required string BucketID { get; set; }

	[Column("path")]
	public required string Path { get; set; }

	[Column("iv")]
	public required string IV { get; set; }

	[Column("metadata", TypeName = "jsonb")]
	public required FileMetadata Metadata { get; set; }

	[Column("content_type")]
	public required string ContentType { get; set; }

	[Column("size")]
	public ulong Size { get; set; }
}
