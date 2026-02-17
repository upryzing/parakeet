using System.Net;
using System.Net.Mime;
using System.Text.Json;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Parakeet.Core.Controllers;

// NOTE TO SELF: must be public or it won't be exposed
[ApiController]
[Route("/test")]
[Produces(MediaTypeNames.Application.Json)]
public class TestController : ControllerBase {
	[HttpGet]
	public JsonResult Get() {
		var test = new {
			msg = "Hello idiot! :3333"
		};

		return new JsonResult(test);
	}
}