using PCLStorage;
using RacingDigitalAssignment.Data.Models;
using SQLite;
using System.Net.Mail;
using System.Reflection.PortableExecutable;
using Uno.UI.Extensions;
using Windows.Storage;

namespace RacingDigitalAssignment.Data
{
    public class SqLiteDatabaseContext : ISqLiteDatabaseContext
    {
        private SQLiteAsyncConnection sqliteDatabase;

        async Task Init()
        {
            if (sqliteDatabase is not null)
                return;


            await ApplicationData.Current.LocalFolder.CreateFileAsync(Constants.DatabaseFilename, Windows.Storage.CreationCollisionOption.OpenIfExists);
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path,
                                        Constants.DatabaseFilename);
            sqliteDatabase = new SQLiteAsyncConnection(dbpath, Constants.Flags);

            await sqliteDatabase.CreateTableAsync<Horse>();
            await sqliteDatabase.CreateTableAsync<Jockey>();
            await sqliteDatabase.CreateTableAsync<Race>();
            await sqliteDatabase.CreateTableAsync<RaceCourse>();
            await sqliteDatabase.CreateTableAsync<Trainer>();
            await sqliteDatabase.CreateTableAsync<RaceNote>();
            await sqliteDatabase.CreateTableAsync<RaceRaceNote>();
        }
        public async Task<int> GenericEntityListSave<T>(List<T> entities)
        {
            try
            {
                await Init();
                entities.ForEach(async __ =>
                {
                    await sqliteDatabase.InsertOrReplaceAsync(__);
                });
                return 1;
            }
            catch { return 0; }
        }
        public async Task<int> GenericEntitySave<T>(T entity)
        {
            try
            {
                await Init();
                await sqliteDatabase.InsertOrReplaceAsync(entity);
                return 1;
            }
            catch { return 0; }
        }
        public async Task<int> SaveRaceAsync(Race race)
        {
            try
            {
                await Init();
                var result = await sqliteDatabase.InsertOrReplaceAsync(race);
                return (int)race.RaceID;
            }
            catch { return 0; }
        }
        public async Task<int> SaveRaceCourseAsync(RaceCourse raceCourse)
        {
            try
            {
                await Init();
                var result = await sqliteDatabase.InsertOrReplaceAsync(raceCourse);
                return (int)raceCourse.RaceCourseID;
            }
            catch { return 0; }
        }
        public async Task<int> SaveJockeyAsync(Jockey jockey)
        {
            try
            {
                await Init();
                var result = await sqliteDatabase.InsertOrReplaceAsync(jockey);
                return (int)jockey.JockeyID;
            }
            catch { return 0; }
        }
        public async Task<int> SaveTrainerAsync(Trainer trainer)
        {
            try
            {
                await Init();
                var result = await sqliteDatabase.InsertOrReplaceAsync(trainer);
                return (int)trainer.TrainerID;
            }
            catch { return 0; }
        }
        public async Task<int> SaveHorseAsync(Horse horse)
        {
            try
            {
                await Init();
                var result = await sqliteDatabase.InsertOrReplaceAsync(horse);
                return (int)horse.HorseID;
            }
            catch { return 0; }
        }

        public async Task<List<Race>> GetRaceResultsAsync(DateTime startDate,DateTime endDate)
        {
            await Init();
            return await sqliteDatabase.Table<Race>().Where(__ => __.RaceDate >= startDate && __.RaceDate <= endDate).ToListAsync();
        }

        public async Task<int> GenericEntityDelete<T>(T entity)
        {
            try
            {
                await Init();
                await sqliteDatabase.DeleteAsync(entity);
                return 1;
            }
            catch { return 0; }
        }
    }
}



