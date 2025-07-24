using CsvHelper;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using RacingDigitalAssignment.Data;
using RacingDigitalAssignment.Data.Models;
using RacingDigitalAssignment.Models;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Xml.Linq;

namespace RacingDigitalAssignment.Services
{
    public class DataService: IDataService
    {
        private ISqLiteDatabaseContext _sqLiteDatabaseContext;
        public DataService(ISqLiteDatabaseContext sqLiteDatabaseContext)
        {
            _sqLiteDatabaseContext = sqLiteDatabaseContext;
        }
        public List<RaceImportModel>? ProcessRaceDataFile(FileStream stream)
        {
            using var reader = new StreamReader(stream);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var records = csv.GetRecords<RaceImportModel>();
            return records.ToList();
        }

        public async Task<string> ImportRaceData(List<RaceImportModel> raceImportModels)
        {
            var races = new List<Race>();
            foreach(var raceImportModel in raceImportModels)
            {
                //Add the race course
                var raceDistanceValid = decimal.TryParse(raceImportModel.RaceDistance, out var raceDistance);
                var raceCourseID = await _sqLiteDatabaseContext.SaveRaceCourseAsync(new()
                {
                    Name = raceImportModel.Racecourse ?? "-N/A-",
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    TrackLength = raceDistanceValid ? raceDistance : 0,
                    TrackDescription = "Grass Track"
                });

                //Add the jockey
                var jockeyID = await _sqLiteDatabaseContext.SaveJockeyAsync(new()
                {
                    Name = raceImportModel.Jockey ?? "-N/A-",
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                });

                //Add the trainer
                var trainerID = await _sqLiteDatabaseContext.SaveTrainerAsync(new()
                {
                    Name = raceImportModel.Trainer ?? "-N/A-",
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                });

                //Add the horse
                var horseID = await _sqLiteDatabaseContext.SaveHorseAsync(new()
                {
                    Name = raceImportModel.Horse ?? "-N/A-",
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    Height = 17,
                    Weight = 189
                });

                //Add the race
                var raceDateValid = DateTime.TryParse($"{raceImportModel.RaceDate} {raceImportModel.RaceTime}", out var raceDate);
                var raceID = await _sqLiteDatabaseContext.SaveRaceAsync(new()
                {
                    Name = raceImportModel.Race ?? "-N/A-",
                    
                    RaceDate = raceDateValid?raceDate:DateTime.UtcNow,
                    RaceCourseID = raceCourseID,
                    RaceDistance = raceDistanceValid ? raceDistance : 0,
                    JockeyID = jockeyID,
                    TrainerID = trainerID,
                    HorseID = horseID,
                    FinishingPosition = raceImportModel.FinishingPosition,
                    DistanceBeaten = raceImportModel.DistanceBeaten,
                    TimeBeaten = raceImportModel.TimeBeaten,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                });
            }
            return "success";
        }
    }
}
