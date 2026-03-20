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

namespace Parakeet.Core.Auth.Tables;

public enum InviteType : Byte {
	SingleUse,
	MultipleUse
}

// Local registered users
[Table("invites")]
[Index(nameof(ID), IsUnique = true)]
[Index(nameof(Type))]
[Index(nameof(ClaimedBy))]
[Index(nameof(Valid))]
public class Invite {
	[Column("id")]
	public Guid ID { get; set; }

	/**
	<summary>
	The type of invite code.<br/>
	Both can be invalidated with the <c>Valid</c> property but <c>SingleUse</c> can be invalidated with <c>ClaimedBy</c> as well.<br/>
	We can't actually store it as a byte so we have to use smallint (2 bytes). Mild inefficiency at the hands of postgresql.
	</summary>
	*/
	[Column("type", TypeName = "smallint")]
	public InviteType Type { get; set; }

	/**
	<summary>
	The amount of times this invite can be used before becoming invalid.<br/>
	Not set if <c>Type</c> is set to <c>SingleUse</c>.<br/>
	If set to -1, it is considered infinite.
	</summary>
	*/
	[Column("remainingUses")]
	public int RemainingUses { get; set; }

	/**
	<summary>
	The user Guid that claimed this invite code.<br/>
	Not set if <c>Type</c> is set to <c>MultipleUse</c>
	</summary>
	*/
	[Column("claimedBy")]
	public Guid? ClaimedBy { get; set; }

	[Column("valid")]
	[DefaultValue(true)]
	public bool Valid { get; set; }
};
