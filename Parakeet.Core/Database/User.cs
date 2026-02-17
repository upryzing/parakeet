using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.Projectables;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Parakeet.Core.Database {
	// UNFINISHED
	[Table("user")]
	[Index(nameof(ID), nameof(Homeserver), IsUnique = true)]
	[Index(nameof(Username), nameof(Homeserver), IsUnique = true)]
	[Index(nameof(Homeserver))]
	public class User {
		[Column("id")]
		[StringLength(26)]
		public string ID { get; set; }

		[Column("homeserver")]
		[StringLength(512)]
		public string Homeserver { get; set; }

		[Column("username")]
		[StringLength(128)]
		public string Username { get; set; }
	}
}