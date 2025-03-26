using System;

namespace cpsy200.Data
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public int PersonalDiscount { get; set; }
        public string Notes { get; set; }

        public Customer(string dataLine)
        {
            var parts = dataLine.Split(',');

            CustomerID = int.Parse(parts[0]);
            FirstName = parts[1];
            LastName = parts[2];
            Phone = parts[3];
            Email = parts[4];
            Status = parts[5];
            PersonalDiscount = int.Parse(parts[6]);
            Notes = parts.Length > 7 ? parts[7] : "";
        }

        public string Name => $"{FirstName} {LastName}"; // Combine first and last name for display

        public override string ToString()
        {
            return $"{CustomerID},{FirstName},{LastName},{Phone},{Email},{Status},{PersonalDiscount},{Notes}";
        }
    }
}
