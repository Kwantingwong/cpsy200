using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cpsy200.Data
{
    public class EquipmentManager
    {
        // Change the path to match where your CSV file is stored in MAUI
        private static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                @"..\..\..\..\Resources\Res\equipment_list.csv");

        public static List<Equipment> GetEquipmentList()
        {
            List<Equipment> equipmentList = new List<Equipment>();

            if (!File.Exists(filePath))
                return equipmentList;

            using var fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read);
            using var sr = new StreamReader(fs);

            string line;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(line))
                {
                    Equipment equipment = new Equipment(line);
                    equipmentList.Add(equipment);
                }
            }

            return equipmentList.OrderBy(e => e.EquipmentName).ToList();
        }

        public static void SaveEquipmentList(List<Equipment> list)
        {
            using var sw = new StreamWriter(filePath, false);
            foreach (var item in list)
            {
                sw.WriteLine($"{item.EquipmentID},{item.CategoryID},{item.EquipmentName},{item.Description},{item.Status},{item.Condition},{item.Location},{item.DailyRentalCost}");
            }
        }
    }
}
