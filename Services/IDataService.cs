using CsvHelper;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using RacingDigitalAssignment.Models;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;

namespace RacingDigitalAssignment
{
    public interface IDataService
    {
        List<RaceImportModel>? ProcessRaceDataFile(FileStream stream);
        Task<string> ImportRaceData(List<RaceImportModel> raceImportModels);
    }
}
