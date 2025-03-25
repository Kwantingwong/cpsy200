using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cpsy200.Data
{
    public class Rental
    {
        public int RentalID { get; set; }
        public int CustomerID { get; set; }
        public int EquipmentID { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal CostOfRental { get; set; }
        public decimal TotalCost { get; set; }

        public Rental(string csvLine)
        {
            var parts = csvLine.Split(',');
            RentalID = int.Parse(parts[0]);
            CustomerID = int.Parse(parts[1]);
            EquipmentID = int.Parse(parts[2]);
            RentalDate = DateTime.Parse(parts[3]);
            ReturnDate = DateTime.Parse(parts[4]);
            CostOfRental = decimal.Parse(parts[5]);
            TotalCost = decimal.Parse(parts[6]);
        }

        public override string ToString()
        {
            return $"{RentalDate:yyyy-MM-dd} | RentalID: {RentalID}, CustomerID: {CustomerID}, EquipmentID: {EquipmentID}, Total: ${TotalCost}";
        }
    }

}
