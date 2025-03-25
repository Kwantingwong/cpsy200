using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cpsy200.Data
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public int PersonalDiscount { get; set; }
        public string Notes { get; set; }

        public Customer(string dataLine)
        {
            var parts = dataLine.Split(',');

            CustomerID = int.Parse(parts[0]);
            Name = parts[1];
            Email = parts[2];
            Phone = parts[3];
            Address = parts[4];
            Status = parts[5];
            PersonalDiscount = int.Parse(parts[6]);
            Notes = parts.Length > 7 ? parts[7] : "";
        }

        public override string ToString()
        {
            return $"{CustomerID},{Name},{Email},{Phone},{Address},{Status},{PersonalDiscount},{Notes}";
        }
    }

}