using CsvHelper.Configuration.Attributes;
using RacingDigitalAssignment.Data.Models;
using System;

namespace RacingDigitalAssignment.Models
{
    public class RaceImportModel
    {
        public string? Race { get; set; }
        public string? RaceDate { get; set; }
        public string? RaceTime { get; set; }
        public string? Racecourse { get; set; }
        public string? RaceDistance { get; set; }
        public string? Jockey { get; set; }
        public string? Trainer { get; set; }
        public string? Horse { get; set; }
        public int FinishingPosition { get; set; }
        public decimal DistanceBeaten { get; set; }
        public decimal TimeBeaten { get; set; }
    }
}
