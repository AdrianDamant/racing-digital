using SQLite;

namespace RacingDigitalAssignment.Data.Models
{
    public class RaceNote
    {
        [PrimaryKey, AutoIncrement]
        public int? RaceNoteID { get; set; }
        public string? Note { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
