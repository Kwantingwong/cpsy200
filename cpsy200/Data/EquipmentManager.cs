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

        public static List<Equipment> Equipments = new List<Equipment>();

        static EquipmentManager()
        {
            LoadEquipments();
        }

        public static void LoadEquipments()
        {
            Equipments.Clear();
            if (!File.Exists(filePath)) return;

            using FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read);
            using StreamReader sr = new StreamReader(fs);
            string line;

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(line))
                {
                    Equipments.Add(new Equipment(line));
                }
            }
        }

        public static void AddEquipment(Equipment equipment)
        {
            Equipments.Add(equipment);
            SaveEquipments();
        }

        public static void SaveEquipments()
        {
            using StreamWriter sw = new StreamWriter(filePath, false);
            foreach (var equipment in Equipments)
            {
                sw.WriteLine(equipment.ToString()); 
            }
        }

        public static List<Equipment> GetAll() => Equipments;
    }
}
