using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cpsy200.Data
{
    public static class RentalManager
    {
        private static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\Resources\Res\rental_list.csv");
        public static List<Rental> Rentals = new List<Rental>();

        static RentalManager()
        {
            LoadRentals();
        }

        public static void LoadRentals()
        {
            Rentals.Clear();
            if (!File.Exists(filePath)) return;

            foreach (var line in File.ReadAllLines(filePath))
            {
                if (!string.IsNullOrWhiteSpace(line))
                    Rentals.Add(new Rental(line));
            }
        }

        public static List<Rental> GetAll() => Rentals;
    }

}
