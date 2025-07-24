using CsvHelper.Configuration.Attributes;
using SQLite;

namespace RacingDigitalAssignment.Data.Models
{
    public class Race
    {
        [PrimaryKey, AutoIncrement]
        public int? RaceID { get; set; }
        public string Name { get; set; }
        public DateTime RaceDate { get; set; }
        public int RaceCourseID { get; set; }
        public decimal RaceDistance { get; set; }
        public int JockeyID { get; set; }
        public int TrainerID { get; set; }
        public int HorseID { get; set; }
        public int FinishingPosition { get; set; }
        public decimal DistanceBeaten { get; set; }
        public decimal TimeBeaten { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        [SQLite.Ignore]
        private Horse Horse { get; set; }

    }
}
