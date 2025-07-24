using SQLite;

namespace RacingDigitalAssignment.Data.Models
{
    public class RaceCourse
    {
        [PrimaryKey, AutoIncrement]
        public int? RaceCourseID { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public decimal TrackLength { get; set; }
        public string? TrackDescription { get; set; }
    }
}
