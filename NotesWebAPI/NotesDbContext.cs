using Microsoft.EntityFrameworkCore;
using NotesWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesWebAPI
{
	public class NotesDbContext: DbContext
	{
		public DbSet<NoteModel> Notes { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
			optionsBuilder
				.UseSqlite(@"Data Source=notes.db;");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder){
			modelBuilder.Entity<NoteModel>().ToTable("notes");
		}
	}
}
