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
using System.Text.Json.Serialization;

using EntityFrameworkCore.Projectables;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Parakeet.Core.Attachments.Tables;
using Parakeet.Shared.Classes.API;

using FileData = Parakeet.Shared.Classes.API.FileData;

namespace Parakeet.Core.Users.Tables;

// NOTE: Necessary table deviation, C# does not support the way that Parrot did their settings table
[Table("user_settings")]
[Index(nameof(ID), IsUnique = true)]
public class UserSettings {
	[Column("id")]
	[Required]
	public Guid ID { get; set; }

	[Column("settings")]
	[Required]
	public required Dictionary<string, Tuple<Int64, string>> Settings { get; set; }
};