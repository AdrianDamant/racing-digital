using SQLite;

namespace RacingDigitalAssignment.Data.Models
{
    public class Horse
    {
        [PrimaryKey, AutoIncrement]
        public int? HorseID { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
    }
}
