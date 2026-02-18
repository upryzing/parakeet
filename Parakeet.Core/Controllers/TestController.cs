using System.Net;
using System.Net.Mime;
using System.Text.Json;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

using Parakeet.Core.Database;

namespace Parakeet.Core.Controllers;

// NOTE TO SELF: must be public or it won't be exposed
[ApiController]
[Route("/test")]
[Produces(MediaTypeNames.Application.Json)]
public class TestController(DatabaseContext dbContext) : ControllerBase {
	[HttpGet]
	public JsonResult Get() {
		var test = new {
			msg = "Hello idiot! :3333"
		};

		return new JsonResult(test);
	}

	[HttpGet]
	[Route("/test/usr")]
	public async Task<JsonResult> GetTest() {
		User usr = new() { ID = "test", Homeserver = "localhost", Username = "Test", UsernameLower = "test" };
		_db.Users.Add(usr);

		await _db.SaveChangesAsync();

		var json = new {
			msg = "Check the db"
		};

		return new JsonResult(json);
	}

	private readonly DatabaseContext _db = dbContext;
}