using RacingDigitalAssignment.Data.Models;

namespace RacingDigitalAssignment.Data
{
    public interface ISqLiteDatabaseContext
    {
        Task<int> GenericEntityListSave<T>(List<T> entities);
        Task<int> GenericEntitySave<T>(T entity);
        Task<int> SaveRaceAsync(Race race);
        Task<int> GenericEntityDelete<T>(T entity);
        Task<int> SaveRaceCourseAsync(RaceCourse raceCourse);
        Task<int> SaveJockeyAsync(Jockey jockey);
        Task<int> SaveTrainerAsync(Trainer trainer);
        Task<int> SaveHorseAsync(Horse horse);
        Task<List<Race>> GetRaceResultsAsync(DateTime startDate, DateTime endDate);
    }
}
