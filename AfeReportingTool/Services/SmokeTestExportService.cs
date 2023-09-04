using AfeReportingTool.Templates;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using SmokeTestDataImport.Data;
using SmokeTestDataImport.Models;

namespace AfeReportingTool.Services
{
    public class SmokeTestExportService : ISmokeTestExportService
	{
		private readonly SmokeTestingDbContext _dbContext;
        private readonly SmokeTestReportTemplate _template;

        public SmokeTestExportService(SmokeTestingDbContext dbContext, SmokeTestReportTemplate template)
        {
            _dbContext = dbContext;
            _template = template;
        }

        public void ExportReports(string outputDirectory, SmokeTestingDbContext _dbContext)
        {
            var defectsForReport = SelectDefectsToExport(_dbContext);

            foreach(SmokeDefect defect in defectsForReport)
            {
                var reportName = $"{defect.UniqueId}_{defect.Location}.pdf";

                GeneratePdf(defect, outputDirectory, reportName, _template);
            }
        }

        public List<SmokeDefect> SelectDefectsToExport(SmokeTestingDbContext _dbContext)
        {
            List<SmokeDefect> defectsforReport = new List<SmokeDefect>();

            defectsforReport = _dbContext.SmokeDefects.Where(s => s.IsProcessed == 0).ToList();

            return defectsforReport;
        }

        public void GeneratePdf(SmokeDefect defect, string outputDirectory, string reportName, SmokeTestReportTemplate _template)
        {

            var report = _template.FormatDefectReport(defect);

            //enhancement - zip up all files
            try
            {
                report.Save(Path.Combine(outputDirectory, reportName));
            }
            catch (Exception ex)
            {
                string currentUser = Environment.UserName;
                Console.WriteLine(currentUser);
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }

        public void ArchiveImages(string imageToArchive, string imageArchiveDirectory)
        {

        }
    }
}

