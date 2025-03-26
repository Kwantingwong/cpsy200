using System;

namespace cpsy200.Data
{
    public class Report
    {
        public int ReportID { get; set; }
        public int GeneratedBy { get; set; }
        public string ReportType { get; set; }
        public DateTime GeneratedDate { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }

        // Constructor with necessary parameters
        public Report(int reportID, int generatedBy, string reportType, DateTime generatedDate, string content, string name)
        {
            ReportID = reportID;
            GeneratedBy = generatedBy;
            ReportType = reportType;
            GeneratedDate = generatedDate;
            Content = content;
            Name = name;
        }

        public Report() { }  // Default constructor if needed

        public override string ToString()
        {
            return $"{ReportID}, {GeneratedBy}, {ReportType}, {GeneratedDate}, {Content}, {Name}";
        }
    }
}
