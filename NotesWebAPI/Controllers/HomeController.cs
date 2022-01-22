using Microsoft.AspNetCore.Mvc;
using NotesWebAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace NotesWebAPI.Controllers
{
	public class HomeController : Controller
	{
		private HttpClient client = new HttpClient();
		[HttpGet("/")]
		public IActionResult GetIndex()
		{
			return new FileStreamResult(System.IO.File.OpenRead(Path.Join("static", "html", "index.html")), contentType: "text/html");
		}
		[HttpPost("/notes")]
		public IActionResult PostNote()
		{
			var noteModel = new NoteModel(Request.Form["note"]);
			var serialized = JsonConvert.SerializeObject(noteModel);

			var content = new StringContent(serialized, Encoding.UTF8, "application/json");
			var message = new HttpRequestMessage(HttpMethod.Post, $"{Program.BaseHttpUrl}api/notes");
			message.Content = content;
			var resp = client.Send(message);

			return new RedirectResult("/");
		}
	}
}
