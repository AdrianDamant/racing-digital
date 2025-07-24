using SQLite;

namespace RacingDigitalAssignment.Data.Models
{
    public class Jockey
    {
        [PrimaryKey, AutoIncrement]
        public int? JockeyID { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
