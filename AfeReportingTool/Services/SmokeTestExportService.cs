using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using SmokeTestDataImport.Data;
using SmokeTestDataImport.Models;

namespace AfeReportingTool.Services
{
    public class SmokeTestExportService : ISmokeTestExportService
	{
		private readonly SmokeTestingDbContext _dbContext;

        public void ExportReports(string outputDirectory, SmokeTestingDbContext _dbContext)
        {
            var defectsForReport = SelectDefectsToExport(_dbContext);

            foreach(SmokeDefect defect in defectsForReport)
            {
                GeneratePdf(defect, outputDirectory);
            }
        }

        public List<SmokeDefect> SelectDefectsToExport(SmokeTestingDbContext _dbContext)
        {
            List<SmokeDefect> defectsforReport = new List<SmokeDefect>();

            defectsforReport = _dbContext.SmokeDefects.Where(s => s.IsProcessed == 0).ToList();

            return defectsforReport;
        }

        public void GeneratePdf(SmokeDefect defect, string outputDirectory)
        {
            PdfDocument report = new PdfDocument();

            PdfPage page = report.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            var data = $"Defect ID: {defect.UniqueId}\nLocation: {defect.Location}\nSmoke Rate: {defect.SmokeRate}";
            XFont font = new XFont("Arial", 12);
            XRect rect = new XRect(50, 100, page.Width - 100, page.Height - 200);
            gfx.DrawString(data, font, XBrushes.Black, rect, XStringFormats.TopLeft);

            report.Save(outputDirectory);
        }

        public void ArchiveImages(string imageToArchive, string imageArchiveDirectory)
        {

        }
    }
}

