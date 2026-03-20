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

[ComplexType]
public class UsedFor {
	public string Type;
	
	public Guid ID;
}

// Local registered users
[Table("attachments")]
[Index(nameof(ID), IsUnique = true)]
[Index(nameof(Hash), IsUnique = true)]
public class Attachment {
	[Column("id")]
	public Guid ID { get; set; }

	[Column("tag")]
	public string Tag { get; set; }

	[Column("filename")]
	public string Filename { get; set; }

	/**
	<summary>
	A SHA512 hash, as a string ()
	</summary>
	*/
	[Column("hash")]
	public string Hash { get; set; }

	[Column("uploadedAt")]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public DateTime UploadedAt { get; set; }

	[Column("uploaderID")]
	public Guid UploaderID { get; set; }

	// These three were originally part of attachment_hashes but like, what was the point?
	[Column("bucketID")]
	public string BucketID { get; set; }

	[Column("path")]
	public string Path { get; set; }

	[Column("iv")]
	public string IV { get; set; }

	[Column("metadata", TypeName = "jsonb")]
	public FileMetadata Metadata { get; set; }

	[Column("contentType")]
	public string ContentType { get; set; }

	[Column("size")]
	public ulong Size { get; set; }
};
