using System;

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
        public string Status { get; set; } // Added for the form
        public string Notes { get; set; }  // Added for the form

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
            Status = parts.Length > 7 ? parts[7] : "Rented"; // Default to "Rented" if not present
            Notes = parts.Length > 8 ? parts[8] : string.Empty; // Default to empty if not present
        }

        public Rental()
        {
            // Parameterless constructor for creating new rentals
        }

        public override string ToString()
        {
            return $"{RentalDate:yyyy-MM-dd} | RentalID: {RentalID}, CustomerID: {CustomerID}, EquipmentID: {EquipmentID}, Total: ${TotalCost}";
        }

        // Method to convert the rental to a CSV line
        public string ToCsvLine()
        {
            return $"{RentalID},{CustomerID},{EquipmentID},{RentalDate:yyyy-MM-dd},{ReturnDate:yyyy-MM-dd},{CostOfRental},{TotalCost},{Status},{Notes}";
        }
    }
}