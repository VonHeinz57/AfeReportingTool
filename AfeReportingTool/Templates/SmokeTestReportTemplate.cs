using System;
using PdfSharpCore.Drawing;
using PdfSharpCore.Fonts;
using PdfSharpCore.Pdf;
using SmokeTestDataImport.Configs;
using SmokeTestDataImport.Models;

namespace AfeReportingTool.Templates
{
	public class SmokeTestReportTemplate : ISmokeTestReportTemplate
	{
        //enhancement - generalize some of the variables here. storing a ton of strings which get kept in memory for long time
		public PdfDocument FormatDefectReport(SmokeDefect defect)
        {
            var photoDir = new AppConfiguration().photoDirectory;

            var report = new PdfDocument();

            var page = report.AddPage();
            var gfx = XGraphics.FromPdfPage(page);

            var pageWidth = page.Width.Point;
            var pageHeight = page.Height.Point;
            var leftAlign = pageWidth * 0.1;
            var border = new XPen(XColors.Black, 1);

            //header
            //enhancement - dynamically get the Report Location
            var header = $"Franklin, TN Smoke Test Report";
            var headerFont = new XFont("Arial", 14);
            var headerXPos = leftAlign;
            var headerYPos = pageWidth * 0.05;
            var headerWidth = pageWidth * 0.8;
            var headerHeight = pageHeight * 0.03;

            var headerTextSize = gfx.MeasureString(header, headerFont).Height;
            var headerTextX = headerXPos + 5;
            var headerTextY = headerYPos + headerHeight/2 + headerTextSize/2; 

            gfx.DrawString(header, headerFont, XBrushes.Black, headerTextX, headerTextY);


            //Defect Details - header
            var defectDetailsHeader = $"Defect Details";
            var defectDetailsFont = new XFont("Arial", 12);
            var defectDetailsXPos = leftAlign;
            var defectDetailsYPos = headerYPos + headerHeight;

            var defectDetailsTextSize = gfx.MeasureString(defectDetailsHeader, headerFont).Height;
            var defectDetailsTextX = defectDetailsXPos + 5;
            var defectDetailsTextY = defectDetailsYPos + headerHeight / 2 + defectDetailsTextSize / 2;

            var rect = new XRect(defectDetailsXPos, defectDetailsYPos, headerWidth, headerHeight);
            gfx.DrawRectangle(border, rect);
            gfx.DrawString(defectDetailsHeader, defectDetailsFont, XBrushes.Black, defectDetailsTextX, defectDetailsTextY);


            //Defect Details - data
            var defectDetailsDataXPos = leftAlign;
            var defectDetailsDataYPos = defectDetailsYPos + headerHeight;
            var defectDetailsDataWidth = headerWidth;
            var defectDetailsDataHeight = pageHeight * 0.4;
            var defectDetailsData = new XRect(defectDetailsDataXPos, defectDetailsDataYPos, defectDetailsDataWidth, defectDetailsDataHeight);
            gfx.DrawRectangle(border, defectDetailsData);

            //Address/Location
            var addressLoc = $"Address/Location: {defect.Location}";
            var defectDetailsDataFont = new XFont("Arial", 10);
            var defectDetailsDataTextSize = gfx.MeasureString(header, headerFont).Height;
            var addressLocXPos = leftAlign + 15;
            var addressLocYPos = defectDetailsDataYPos + defectDetailsDataTextSize;

            gfx.DrawString(addressLoc, defectDetailsDataFont, XBrushes.Black, addressLocXPos, addressLocYPos);

            //Defect Type
            var defectType = $"Defect Type: {defect.DefectTyp}";
            var defectTypeXPos = addressLocXPos;
            var defectTypeYPos = addressLocYPos + defectDetailsDataTextSize;

            gfx.DrawString(defectType, defectDetailsDataFont, XBrushes.Black, defectTypeXPos, defectTypeYPos);

            //Smoke Rate
            var smokeRate = $"Smoke Rate: {defect.SmokeRate}";
            var smokeRateXPos = addressLocXPos;
            var smokeRateYPos = defectTypeYPos + defectDetailsDataTextSize;

            gfx.DrawString(smokeRate, defectDetailsDataFont, XBrushes.Black, smokeRateXPos, smokeRateYPos);

            //Datetime
            var datetime = $"Datetime: {defect.GpsDate} {defect.GpsTime}";
            var datetimeXPos = addressLocXPos;
            var datetimeYPos = smokeRateYPos + defectDetailsDataTextSize;

            gfx.DrawString(datetime, defectDetailsDataFont, XBrushes.Black, datetimeXPos, datetimeYPos);

            //Runoff Potential
            var runoffPot = $"Runoff Potential: {defect.RunoffPot}";
            var runoffPotXPos = pageWidth/2 + 10;
            var runoffPotYPos = addressLocYPos;

            gfx.DrawString(runoffPot, defectDetailsDataFont, XBrushes.Black, runoffPotXPos, runoffPotYPos);

            //Drainage Area
            var drainageArea = $"Drainage Area: {defect.DrainageA}";
            var drainageAreaXPos = runoffPotXPos;
            var drainageAreaYPos = defectTypeYPos;

            gfx.DrawString(drainageArea, defectDetailsDataFont, XBrushes.Black, drainageAreaXPos, drainageAreaYPos);

            //Elevation
            var elevation = $"Elevation: {defect.Grade}";
            var elevationXPos = runoffPotXPos;
            var elevationYPos = smokeRateYPos;

            gfx.DrawString(elevation, defectDetailsDataFont, XBrushes.Black, elevationXPos, elevationYPos);

            //Surface Coverage
            var surfaceCoverage = $"Surface Coverage: {defect.SurfaceCo}";
            var surfaceCoverageXPos = runoffPotXPos;
            var surfaceCoverageYPos = datetimeYPos;

            gfx.DrawString(surfaceCoverage, defectDetailsDataFont, XBrushes.Black, surfaceCoverageXPos, surfaceCoverageYPos);

            //Comments
            var comments = $"Comments: {defect.GeneralCo}";
            var commentsXPos = addressLocXPos;
            var commentsYPos = datetimeYPos + defectDetailsDataTextSize;

            gfx.DrawString(comments, defectDetailsDataFont, XBrushes.Black, commentsXPos, commentsYPos);

            //Area Photo - header
            var areaPhotoHeader = $"Area Photo";
            var areaPhotoHeaderXPos = addressLocXPos;
            var areaPhotoHeaderYPos = commentsYPos + defectDetailsDataTextSize*2;

            //Zoom Photo - header
            var zoomPhotoHeader = $"Zoom Photo";
            var zoomPhotoHeaderXPos = runoffPotXPos;
            var zoomPhotoHeaderYPos = commentsYPos + defectDetailsDataTextSize * 2;

            gfx.DrawString(areaPhotoHeader, defectDetailsDataFont, XBrushes.Black, areaPhotoHeaderXPos, areaPhotoHeaderYPos);
            gfx.DrawString(zoomPhotoHeader, defectDetailsDataFont, XBrushes.Black, zoomPhotoHeaderXPos, zoomPhotoHeaderYPos);

            //Defect Location - header
            var defectLocationHeader = $"Defect Location";
            var defectLocationFont = new XFont("Arial", 12);
            var defectLocationXPos = leftAlign;
            var defectLocationYPos = defectDetailsDataYPos + defectDetailsDataHeight + headerTextSize;

            var defectLocationTextX = defectLocationXPos + 5;
            var defectLocationTextY = defectLocationYPos + headerHeight / 2 + defectDetailsTextSize / 2;

            var locationRect = new XRect(defectLocationXPos, defectLocationYPos, headerWidth, headerHeight);
            gfx.DrawRectangle(border, locationRect);
            gfx.DrawString(defectLocationHeader, defectLocationFont, XBrushes.Black, defectLocationTextX, defectLocationTextY);


            //Defect Location - data
            var defectLocationDataXPos = leftAlign;
            var defectLocationDataYPos = defectLocationYPos + headerHeight;
            var defectLocationDataWidth = headerWidth;
            var defectLocationDataHeight = pageHeight * 0.4;
            var defectLocationData = new XRect(defectLocationDataXPos, defectLocationDataYPos, defectLocationDataWidth, defectLocationDataHeight);
            gfx.DrawRectangle(border, defectLocationData);


            //Area, Zoom, and Map Photos
            //search directory for the actual photo name

            var images = Directory.GetFiles(photoDir);

            var photoWidth = 216;
            var photoHeight = 144;

            var areaPhotoX = addressLocXPos;
            var areaPhotoY = defectDetailsDataHeight - 85;

            var zoomPhotoX = zoomPhotoHeaderXPos;
            var zoomPhotoY = defectDetailsDataHeight - 85;

            var mapPhotoWidth = 465;
            var mapPhotoHeight = 310;

            var mapPhotoX = leftAlign + 11;
            var mapPhotoY = defectLocationDataYPos +4;

            for (int i = 0; i < images.Length; i++)
            {
                string image = images[i];

                if (image.Contains(defect.AreaPhoto.ToString()))
                {
                    var areaPhoto = XImage.FromFile($"{image}");
                    

                    gfx.DrawImage(areaPhoto, areaPhotoX, areaPhotoY, photoWidth, photoHeight);
                }

                if (image.Contains(defect.ZoomPhoto.ToString()))
                {
                    var zoomPhoto = XImage.FromFile($"{image}");

                    gfx.DrawImage(zoomPhoto, zoomPhotoX, zoomPhotoY, photoWidth, photoHeight);
                }

                if(image == $"{photoDir}/Defect {defect.UniqueId}.jpg")
                {
                    var mapPhoto = XImage.FromFile($"{image}");

                    gfx.DrawImage(mapPhoto, mapPhotoX, mapPhotoY, mapPhotoWidth, mapPhotoHeight);
                }
            }

            //footer
            var logo = $"AFE, LLC";
            var footerFont = new XFont("Arial", 12);
            var logoXPos = leftAlign + 5;
            var footerYPos = defectLocationDataYPos + defectLocationDataHeight + gfx.MeasureString(logo, footerFont).Height;

            var dateFoot = $"{DateTime.Now.Date.ToString("MMM")}, {DateTime.Now.Year}";
            var dateXPos = pageWidth * 0.8;

            gfx.DrawString(logo, footerFont, XBrushes.Black, logoXPos, footerYPos);
            gfx.DrawString(dateFoot, footerFont, XBrushes.Black, dateXPos, footerYPos);

            return report;
        }
	}
}

