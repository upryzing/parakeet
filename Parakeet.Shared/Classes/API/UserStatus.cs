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

public enum UserPresence {
	Online,
	Idle,
	Focus,
	Busy,
	Invisible // Has the memory gone? /ref
}

public class UserStatus(string txt, UserPresence presence) {
	public string Text = txt;
	public UserPresence Presence = presence;
}