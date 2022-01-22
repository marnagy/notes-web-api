using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace NotesWebAPI.Models
{
	public class NoteModel: BaseModel, IEquatable<NoteModel>
	{
		[DataType(DataType.Text)]
		[JsonProperty]
		public string Note { get; set;}
		public NoteModel(string note)
		{
			if (note == null)
				throw new ArgumentNullException(nameof(note), $"{nameof(note)} cannot be null");

			Note = note;
		}

		public bool Equals(NoteModel other)
		{
			return Note  == other.Note;
		}
	}
}
