using System;
using SQLite;

namespace DreamScapeMAUI.Models
{
    [Table("user")]
    public class Note
	{
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set;}

        public string NoteText { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}

