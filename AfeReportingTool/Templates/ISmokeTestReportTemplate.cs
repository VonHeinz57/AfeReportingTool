using System;
using PdfSharpCore.Pdf;
using SmokeTestDataImport.Models;

namespace AfeReportingTool.Templates
{
	public interface ISmokeTestReportTemplate
	{
        public PdfPage FormatDefectReport(SmokeDefect defect, PdfDocument report);

    }
}

