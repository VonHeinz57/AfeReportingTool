using OfficeOpenXml;
using SmokeTestDataImport.Configs;
using SmokeTestDataImport.Data;
using SmokeTestDataImport.Models;
using SmokeTestDataImport.Services;

public class SmokeTestImportService : ISmokeTestImportService
{
    private readonly SmokeTestingDbContext _dbContext;

    public void ImportFiles(SmokeTestingDbContext _dbContext)
    {
        var workingDirectory = new AppConfiguration().workingDirectory;
        var archiveDirectory = new AppConfiguration().archiveDirectory;

        var filesToProcess = Directory.GetFiles(workingDirectory, "*.xlsx");
        ProcessFiles(filesToProcess, _dbContext, workingDirectory, archiveDirectory);
    }

    public void ProcessFiles(string[] filesToProcess, SmokeTestingDbContext _dbContext, string workingDirectory, string archiveDirectory)
    {
        var dataTemplate = new AppConfiguration().dataSheetFormat;
        string[] indexes = dataTemplate.Split("|");

        var fileNumber = _dbContext.SmokeDefects?.Any() == true ? _dbContext.SmokeDefects.Max(s => s.ProjectId) : default(int?);

        if (fileNumber == null)
        {
            fileNumber = 0;
        }
        
        foreach (string file in filesToProcess)
        {
            fileNumber++;

            var excelDataSheet = new ExcelPackage(file);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var worksheet = excelDataSheet.Workbook.Worksheets[0];
            var rows = worksheet.Dimension.Rows;

            var smokeDefects = new List<SmokeDefect>();

            for (int row = 2; row <= rows; row++)
            {
                try
                {
                    DateTime gpsDateTime = (DateTime)worksheet.Cells[row, Array.IndexOf(indexes, "Gps_Date") + 1].Value;
                    var gpsDate = new DateOnly(gpsDateTime.Year, gpsDateTime.Month, gpsDateTime.Day);

                    var data = new SmokeDefect
                    {
                        ProjectId = (int)fileNumber,
                        DefectTyp = worksheet.Cells[row, Array.IndexOf(indexes, "Defect_Typ") + 1].Value?.ToString(),
                        Location = worksheet.Cells[row, Array.IndexOf(indexes, "Location") + 1].Value?.ToString(),
                        SmokeRate = worksheet.Cells[row, Array.IndexOf(indexes, "Smoke_Rate") + 1].Value?.ToString(),
                        SurfaceCo = worksheet.Cells[row, Array.IndexOf(indexes, "Surface_Co") + 1].Value?.ToString(),
                        Grade = worksheet.Cells[row, Array.IndexOf(indexes, "Grade") + 1].Value?.ToString(),
                        RunoffPot = worksheet.Cells[row, Array.IndexOf(indexes, "Runoff_Pot") + 1].Value?.ToString(),
                        DrainageA = worksheet.Cells[row, Array.IndexOf(indexes, "Drainage_A") + 1].Value?.ToString(),
                        AreaPhoto = Convert.ToInt32(worksheet.Cells[row, Array.IndexOf(indexes, "Area_Photo") + 1].Value),
                        ZoomPhoto = Convert.ToInt32(worksheet.Cells[row, Array.IndexOf(indexes, "Zoom_Photo") + 1].Value),
                        CrewLeade = worksheet.Cells[row, Array.IndexOf(indexes, "Crew_Leade") + 1].Value?.ToString(),
                        GeneralCo = worksheet.Cells[row, Array.IndexOf(indexes, "General_Co") + 1].Value?.ToString(),
                        OffsetDis = (double?)worksheet.Cells[row, Array.IndexOf(indexes, "Offset_Dis") + 1].Value,
                        OffsetBea = (double?)worksheet.Cells[row, Array.IndexOf(indexes, "Offset_Bea") + 1].Value,
                        GeneralC2 = worksheet.Cells[row, Array.IndexOf(indexes, "General_C2") + 1].Value?.ToString(),
                        GeneralC3 = worksheet.Cells[row, Array.IndexOf(indexes, "General_C3") + 1].Value?.ToString(),
                        ExtraPhot = (int?)worksheet.Cells[row, Array.IndexOf(indexes, "Extra_Phot") + 1].Value,
                        ExtraPho2 = (int?)worksheet.Cells[row, Array.IndexOf(indexes, "Extra_Pho2") + 1].Value,
                        ExtraPho3 = (int?)worksheet.Cells[row, Array.IndexOf(indexes, "Extra_Pho3") + 1].Value,
                        UniqueId = Convert.ToInt32(worksheet.Cells[row, Array.IndexOf(indexes, "Unique_Id") + 1].Value),
                        GpsDate = gpsDate,
                        GpsTime = worksheet.Cells[row, Array.IndexOf(indexes, "Gps_Time") + 1].Value.ToString(),
                        GnssHeigh = (double)worksheet.Cells[row, Array.IndexOf(indexes, "Gnss_Heigh") + 1].Value,
                        Northing = (double)worksheet.Cells[row, Array.IndexOf(indexes, "Northing") + 1].Value,
                        Easting = (double)worksheet.Cells[row, Array.IndexOf(indexes, "Easting") + 1].Value,
                        IsProcessed = 0
                    };
                    smokeDefects.Add(data);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            foreach(SmokeDefect smokeDefect in smokeDefects)
            {
                _dbContext.SmokeDefects.Add(smokeDefect);
            }

            _dbContext.SaveChanges();

            ArchiveFile(file, workingDirectory, archiveDirectory);
        }
    }

    public void ArchiveFile(string fileToArchive, string workingDirectory, string archiveDirectory)
    {
        //File.Move(Path.Combine(workingDirectory, fileToArchive), Path.Combine(archiveDirectory, fileToArchive));
    }

}
