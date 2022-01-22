using Microsoft.EntityFrameworkCore.Migrations;

namespace NotesWebAPI.Migrations
{
    public partial class RenamedUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NoteModel",
                table: "NoteModel");

            migrationBuilder.RenameTable(
                name: "NoteModel",
                newName: "notes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_notes",
                table: "notes",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_notes",
                table: "notes");

            migrationBuilder.RenameTable(
                name: "notes",
                newName: "NoteModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NoteModel",
                table: "NoteModel",
                column: "Id");
        }
    }
}
