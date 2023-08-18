namespace SmokeTestDataImport.Models
{
    public class SmokeDefect
	{
		public int ProjectId { get; set; }
        public string DefectTyp { get; set; }
        public string Location { get; set; }
        public string SmokeRate { get; set; }
        public string SurfaceCo { get; set; }
        public string Grade { get; set; }
        public string RunoffPot { get; set; }
        public string DrainageA { get; set; }
        public int AreaPhoto { get; set; }
        public int ZoomPhoto { get; set; }
        public string CrewLeade { get; set; }
        public string? GeneralCo { get; set; }
        public double? OffsetDis { get; set; }
        public double? OffsetBea { get; set; }
        public string? GeneralC2 { get; set; }
        public string? GeneralC3 { get; set; }
        public int? ExtraPhot { get; set; }
        public int? ExtraPho2 { get; set; }
        public int? ExtraPho3 { get; set; }
        public int UniqueId { get; set; }
        public DateOnly GpsDate { get; set; }
        public TimeOnly GpsTime { get; set; }
        public float GnssHeigh { get; set; }
        public float Northing { get; set; }
        public float Easting { get; set; }
    }
}

