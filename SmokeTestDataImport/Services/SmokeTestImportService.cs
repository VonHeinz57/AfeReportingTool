using System;
using SmokeTestDataImport.Configs;
using SmokeTestDataImport.Data;
using SmokeTestDataImport.Services;
using OfficeOpenXml;
using SmokeTestDataImport.Models;

public class SmokeTestImportService : ISmokeTestImportService
{
    private readonly SmokeTestingDbContext _dbContext;

    public void ImportFiles(SmokeTestingDbContext _dbContext)
    {
        var workingDirectory = new AppConfiguration().workingDirectory;

        var filesToProcess = Directory.GetFiles(workingDirectory);
        ProcessFiles(filesToProcess, _dbContext);
    }

    public void ProcessFiles(string[] filesToProcess, SmokeTestingDbContext _dbContext)
    {
        foreach (string file in filesToProcess)
        {
            var excelDataSheet = new ExcelPackage(file);
            var worksheet = excelDataSheet.Workbook.Worksheets[0];
            var rows = worksheet.Dimension.Rows;

            var smokeDefects = new List<SmokeDefect>();

            for (int row = 2; row <= rows; row++)
            {
                var data = new SmokeDefect
                {
                    Name = worksheet.Cells[row, 1].Value?.ToString(), //put these column indexes into the config; we're going to assume same format every time
                    Age = int.Parse(worksheet.Cells[row, 2].Value?.ToString())
                };
                dataList.Add(data);
            }

            ArchiveFile(file);
        }
    }

    public void ArchiveFile(string fileToArchive)
    {
        //write code to archive the file to the archive directory... probably put the loc to archive in the process files method definition
    }

}
