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
using System.ComponentModel.DataAnnotations.Schema;

namespace Parakeet.Shared.Classes.API;

[ComplexType]
public class FileData(string fileID, string fileTag, string filename, FileMetadata meta, string type, UInt64 size) {
	public readonly string ID = fileID;
	public readonly string Tag = fileTag;

	public readonly string Filename = filename;

	public readonly FileMetadata Metadata = meta;

	/**
	<summary>
	MIMETYPE IF YOU'RE A NERD (like meeeee *paws at you*)
	</summary>
	*/
	public readonly string MediaType = type;

	/**
	<summary>
	The file's size in bytes.

	Advice: use *ibibytes, not *byte, when displaying.
	</summary>
	*/
	public readonly UInt64 Size = size;
}