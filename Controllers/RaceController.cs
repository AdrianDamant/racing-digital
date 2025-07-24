using Microsoft.AspNetCore.Mvc;
using RacingDigitalAssignment.Data;
using RacingDigitalAssignment.Data.Models;
using System.Xml.Linq;
using Windows.UI;

namespace RacingDigitalAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RaceController : ControllerBase
    {
        private readonly ILogger<RaceController> _logger;
        private ISqLiteDatabaseContext _dbContext;

        public RaceController(ILogger<RaceController> logger, ISqLiteDatabaseContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<List<Race>> GetRaceRsultsAsync(DateTime startDate,DateTime endDate)
        {
            return await _dbContext.GetRaceResultsAsync(startDate, endDate);
        }
    }
}
