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

namespace Parakeet.Core.Users.Tables;

/**
<summary>
A Masquerade mask, allowing you to use a different name, avatar and pronouns for select messages.
</summary>
*/
[Table("masquerades")]
[Index(nameof(ID), IsUnique = true)]
public class Masquerade {
	[Column("id")]
	public Guid ID { get; set; }

	/**
	<summary>
	The owner of this mask.
	</summary>
	*/
	[Column("owner")]
	public Guid Owner { get; set; }

	/**
	<summary>
	The space this mask is associated with.<br/>
	If this is null, it is a global masquerade.
	</summary>
	*/
	[Column("space")]
	public Guid? Space { get; set; }

	/**
	<summary>
	The name for this mask. Functions as a display name
	</summary>
	*/
	[Column("name")]
	public string? Name { get; set; }

	[Column("avatar")]
	public string? Avatar { get; set; }

	/**
	<summary>
	The pronouns for this mask. Useful for systems that do not frequently share pronouns among its members or bridge services.
	</summary>
	*/
	[Column("pronouns")]
	public List<string>? Pronouns { get; set; }

	/**
	<summary>
	The colours for this mask. Requires the `ManageRole` permission to use
	</summary>
	*/
	[Column("colour")]
	public string? Colour { get; set; }
};