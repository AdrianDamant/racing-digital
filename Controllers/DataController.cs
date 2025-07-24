using Microsoft.AspNetCore.Mvc;
using RacingDigitalAssignment.Services;
using System.Text;

namespace RacingDigitalAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : Controller
    {
        private IWebHostEnvironment _webHostEnvironment;
        private IDataService _dataService;

        public DataController(IWebHostEnvironment webHostEnvironment, IDataService dataService)
        {
            _webHostEnvironment = webHostEnvironment;
            _dataService = dataService;
        }

        [HttpPost]
        public async Task<string> UploadCSVFileAsync(IFormFile dataFile)
        {
            try
            {
                string folderName = "Upload";
                string webRootPath = _webHostEnvironment.WebRootPath;
                string newPath = Path.Combine(webRootPath, folderName);
                StringBuilder sb = new StringBuilder();
                if (!Directory.Exists(newPath)) Directory.CreateDirectory(newPath);

                if (dataFile.Length > 0)
                {
                    string sFileExtension = Path.GetExtension(dataFile.FileName).ToLower();
                    string fullPath = Path.Combine(newPath, dataFile.FileName);
                    using var stream = new FileStream(fullPath, FileMode.Create);
                    dataFile.CopyTo(stream);
                    stream.Position = 0;

                    var importedData = _dataService.ProcessRaceDataFile(stream);
                    if (importedData is null) return "Exception - Import Failed";
                    return await _dataService.ImportRaceData(importedData);
                }
            }
            catch{}
            return "Exception - Import Failed";
        }
    }
}
