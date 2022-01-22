using Microsoft.AspNetCore.Mvc;
using NotesWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NotesWebAPI.Controllers
{
	[Route("/api/notes")]
	public class NotesController : Controller
	{
		public readonly NotesDbContext _db;

		public NotesController(NotesDbContext db)
		{
			_db = db;
		}
		[HttpGet]
		public IActionResult Get()
		{
			return new JsonResult(
				_db.Notes
					.Select(n => JsonConvert.SerializeObject(n))
					.ToList()
			);
		}
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] NoteModel noteModel)
		{
			await _db.Notes.AddAsync(noteModel);
			await _db.SaveChangesAsync();
			return Ok();
		}
		[HttpDelete]
		[Route("/api/notes/{id}")]
		//public async Task<IActionResult> Delete([FromBody] NoteModel noteModel)
		public async Task<IActionResult> Delete(int id)
		{
			NoteModel note = await _db.Notes.FindAsync(id);
			if (note != null)
			{
				_db.Remove(note);
				await _db.SaveChangesAsync();
			}
			return Ok();
		}
	}
}
