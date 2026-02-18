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

namespace Parakeet.Shared.Classes.API;

/**
<summary>
Session for Parakeet instances.
</summary>
<remarks>
CONSIDER: permissions for a given session? Could be good for apps you don't trust.<br/>
Example: CanSendMessages, CanModifyAccountSettings
</remarks>
*/
public class Session(String sessionID, Ulid sessionUlid, String sessionName, String? token) {
	public readonly String ID = sessionID;
	public readonly Ulid AssociatedUlid = sessionUlid;

	public readonly String Name = sessionName;

	public readonly String? Token = token;
}