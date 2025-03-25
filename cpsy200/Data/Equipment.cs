using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cpsy200.Data
{
    public class Equipment
    {
        public int EquipmentID { get; set; }
        public int CategoryID { get; set; }
        public string EquipmentName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Condition { get; set; }
        public string Location { get; set; }
        public decimal DailyRentalCost { get; set; }
        public string Notes { get; set; }  

        public Equipment(string dataLine)
        {
            // Now expecting: ID,CategoryID,Name,Description,Status,Condition,Location,DailyRentalCost,Notes
            string[] parts = dataLine.Split(',');

            EquipmentID = int.Parse(parts[0]);
            CategoryID = int.Parse(parts[1]);
            EquipmentName = parts[2];
            Description = parts[3];
            Status = parts[4];
            Condition = parts[5];
            Location = parts[6];
            DailyRentalCost = decimal.Parse(parts[7]);
            Notes = parts.Length > 8 ? parts[8] : "";

        }

        public override string ToString()
        {
            // Wrap Notes in quotes and escape any quotes inside the note
            return $"{EquipmentID},{CategoryID},{EquipmentName},{Description},{Status},{Condition},{Location},{DailyRentalCost},{Notes}";
        }


    }
}
