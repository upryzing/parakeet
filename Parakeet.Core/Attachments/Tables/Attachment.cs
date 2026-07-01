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
using System.Text.Json.Serialization;

using EntityFrameworkCore.Projectables;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Npgsql;
using NpgsqlTypes;

using Parakeet.Shared.Classes.API;

namespace Parakeet.Core.Attachments.Tables;

public class UsedFor {
	[JsonPropertyName("type")]
	public string Type;
	
	[JsonPropertyName("id")]
	public Guid ID;
}

public class FileMetadata {
	[JsonPropertyName("type")]
	public FileMetatype Type;

	/**
	<summary>
	Width of a given image. Unused if Type != FileMetatype.Image OR FileMetatype.Video
	</summary>
	*/
	[JsonPropertyName("width")]
	public uint Width;

	/**
	<summary>
	Height of a given image. Unused if Type != FileMetatype.Image OR FileMetatype.Video
	</summary>
	*/
	[JsonPropertyName("height")]
	public uint Height;
}

// Local registered users
[Table("files")]
[Index(nameof(ID), IsUnique = true)]
public class Attachment {
	[Column("id")]
	public Guid ID { get; set; }

	[Column("tag")]
	public string Tag { get; set; }

	[Column("filename")]
	public string Filename { get; set; }

	/**
	<summary>
	A SHA512 hash, as a string
	</summary>
	*/
	[Column("hash")]
	public string Hash { get; set; }

	[Column("uploaded_at")]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public DateTime UploadedAt { get; set; }

	[Column("uploader_id")]
	public Guid UploaderID { get; set; }
	
	[Column("deleted")]
	public bool? Deleted { get; set; }

	[Column("reported")]
	public bool? Reported { get; set; }

	[Column("metadata", TypeName = "jsonb")]
	public required FileMetadata Metadata { get; set; }

	[Column("content_type")]
	public required string ContentType { get; set; }

	[Column("size")]
	public ulong Size { get; set; }

	[Column("message_id")]
	public string? MessageID { get; set; }

	[Column("user_id")]
	public string? UserID { get; set; }

	[Column("server_id")]
	public string? ServerID { get; set; }

	[Column("object_id")]
	public string? ObjectID { get; set; }
};
