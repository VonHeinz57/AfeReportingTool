using System;
using SmokeTestDataImport.Data;

namespace SmokeTestDataImport.Services
{
	public interface ISmokeTestImportService
	{
		public void ImportFiles(SmokeTestingDbContext _dbContext);

		public void ProcessFiles(string[] filesToProcess, SmokeTestingDbContext _dbContext);

		public void ArchiveFile(string fileToArchive);
	}
}

