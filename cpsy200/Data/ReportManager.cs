using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace cpsy200.Data
{
    public static class ReportManager
    {
        private static string reportFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\Resources\Res\report_list.csv");

        // Method to generate a report and save it to CSV
        public static void GenerateAndSaveReport(string reportType, string reportName, string content)
        {
            // Generate a random Report ID
            int reportID = new Random().Next(1000, 9999);
            int generatedBy = 1; // Assume user ID 1 or fetch dynamically
            DateTime generatedDate = DateTime.Now;

            // Create a new Report object using the constructor
            Report newReport = new Report(reportID, generatedBy, reportType, generatedDate, content, reportName);

            // Save the report to the CSV file
            SaveReportToCSV(newReport);
        }

        // Method to save report to the CSV file
        private static void SaveReportToCSV(Report report)
        {
            // Escape newlines and quotes in content
            string escapedContent = report.Content
                .Replace("\"", "\"\"")          // Escape double quotes
                .Replace("\r\n", "\n")          // Normalize newlines
                .Replace("\n", "\\n");          // Encode newlines

            using (var writer = new StreamWriter(reportFilePath, append: true))
            {
                writer.WriteLine($"{report.ReportID},{report.GeneratedDate:yyyy-MM-dd HH:mm:ss},{report.ReportType},{report.Name},\"{escapedContent}\"");
            }
        }

        // Method to read reports from CSV
        public static List<Report> GetReports()
        {
            var reports = new List<Report>();

            if (File.Exists(reportFilePath))
            {
                var lines = File.ReadLines(reportFilePath); // No longer skipping header

                foreach (var line in lines)
                {
                    var parts = SplitCsvLine(line);
                    if (parts.Count < 5) continue;

                    int reportID = int.Parse(parts[0]);
                    DateTime generatedDate = DateTime.Parse(parts[1]);
                    string reportType = parts[2];
                    string name = parts[3];
                    string content = parts[4]
                        .Replace("\\n", "\n")
                        .Replace("\"\"", "\"");

                    var report = new Report(reportID, 1, reportType, generatedDate, content, name);
                    reports.Add(report);
                }
            }

            return reports;
        }

        // Handles quoted CSV fields
        private static List<string> SplitCsvLine(string line)
        {
            var result = new List<string>();
            bool inQuotes = false;
            string current = "";

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];

                if (c == '"')
                {
                    if (inQuotes && i + 1 < line.Length && line[i + 1] == '"')
                    {
                        current += '"';
                        i++;
                    }
                    else
                    {
                        inQuotes = !inQuotes;
                    }
                }
                else if (c == ',' && !inQuotes)
                {
                    result.Add(current);
                    current = "";
                }
                else
                {
                    current += c;
                }
            }

            result.Add(current);
            return result;
        }

        public static void UpdateReport(Report updatedReport)
        {
            var reports = GetReports();
            var index = reports.FindIndex(r => r.ReportID == updatedReport.ReportID);
            if (index != -1)
            {
                reports[index] = updatedReport;
                RewriteAllReports(reports);
            }
        }

        public static void DeleteReport(int reportID)
        {
            var reports = GetReports().Where(r => r.ReportID != reportID).ToList();
            RewriteAllReports(reports);
        }

        private static void RewriteAllReports(List<Report> reports)
        {
            using (var writer = new StreamWriter(reportFilePath, false))
            {
                foreach (var report in reports)
                {
                    string escapedContent = report.Content
                        .Replace("\"", "\"\"")
                        .Replace("\r\n", "\n")
                        .Replace("\n", "\\n");

                    writer.WriteLine($"{report.ReportID},{report.GeneratedDate:yyyy-MM-dd HH:mm:ss},{report.ReportType},{report.Name},\"{escapedContent}\"");
                }
            }
        }

    }
}
