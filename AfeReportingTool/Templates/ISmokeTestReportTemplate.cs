using System;
using PdfSharpCore.Pdf;
using SmokeTestDataImport.Models;

namespace AfeReportingTool.Templates
{
	public interface ISmokeTestReportTemplate
	{
        public PdfDocument FormatDefectReport(SmokeDefect defect);

    }
}

