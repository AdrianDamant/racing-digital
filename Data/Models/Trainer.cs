using SQLite;

namespace RacingDigitalAssignment.Data.Models
{
    public class Trainer
    {
        [PrimaryKey, AutoIncrement]
        public int? TrainerID { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
