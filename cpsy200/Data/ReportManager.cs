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
            // Open the CSV file to append the new report
            using (var writer = new StreamWriter(reportFilePath, append: true))
            {
                writer.WriteLine($"{report.ReportID},{report.GeneratedDate:yyyy-MM-dd HH:mm:ss},{report.ReportType},{report.Name},{report.Content}");
            }
        }

        // Method to read reports from CSV
        public static List<Report> GetReports()
        {
            var reports = new List<Report>();

            if (File.Exists(reportFilePath))
            {
                var lines = File.ReadLines(reportFilePath).Skip(1); // Skip header line

                foreach (var line in lines)
                {
                    var parts = line.Split(',');

                    int reportID = int.Parse(parts[0]);
                    DateTime generatedDate = DateTime.Parse(parts[1]);
                    string reportType = parts[2];
                    string name = parts[3];
                    string content = parts[4];

                    // Create a new Report object with all the parsed fields
                    var report = new Report(reportID, 1, reportType, generatedDate, content, name);
                    reports.Add(report);
                }
            }

            return reports;
        }
    }
}
