using AfeReportingTool.Templates;
using SmokeTestDataImport.Data;
using SmokeTestDataImport.Models;

namespace AfeReportingTool.Services
{
    public interface ISmokeTestExportService
    {
        public void ExportReports(string outputDirectory, SmokeTestingDbContext _dbContext);

        public List<SmokeDefect> SelectDefectsToExport(SmokeTestingDbContext _dbContext);

        public void GeneratePdf(SmokeDefect defect, string outputDirectory, string reportName, SmokeTestReportTemplate _template);

		public void ArchiveImages(string imageToArchive, string imageArchiveDirectory);
	}
}

