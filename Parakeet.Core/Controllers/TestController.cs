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

using System.Net;
using System.Net.Mime;
using System.Text.Json;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

using Parakeet.Core.Database;
using Parakeet.Core.Users.Tables;

namespace Parakeet.Core.Controllers;

// NOTE TO SELF: must be public or it won't be exposed
[ApiController]
[Route("/test")]
[Produces(MediaTypeNames.Application.Json)]
public class TestController(DatabaseContext dbContext) : ControllerBase {
	// Test route: json jumpscare
	[HttpGet]
	public JsonResult Get() {
		var test = new {
			msg = "Hello idiot! :3333"
		};

		return new JsonResult(test);
	}

	/* i cba to update this so this is commented out.
	use as a reference when implementing the real routes ig?
	// Test route: create a user
	[HttpGet]
	[Route("/test/usr")]
	public async Task<JsonResult> GetTest() {
		User usr = new() { ID = (new Ulid()).ToGuid(), Username = "Test" };
		_db.Users.Add(usr);

		await _db.SaveChangesAsync();

		var json = new {
			msg = "Check the db"
		};

		return new JsonResult(json);
	}*/

	[HttpGet]
	[Route("/test/codes/{id}")]
	public async Task<ContentResult> GetCodeTest(int id) {
		return new ContentResult { StatusCode = id, Content = "{}" };
	}

	private readonly DatabaseContext _db = dbContext;
}