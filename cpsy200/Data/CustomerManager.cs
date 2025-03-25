using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cpsy200.Data
{
    public static class CustomerManager
    {
        private static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\Resources\Res\customer_list.csv");
        public static List<Customer> Customers = new List<Customer>();

        static CustomerManager()
        {
            LoadCustomers();
        }

        public static void LoadCustomers()
        {
            Customers.Clear();
            if (!File.Exists(filePath)) return;

            foreach (var line in File.ReadAllLines(filePath))
            {
                if (!string.IsNullOrWhiteSpace(line))
                    Customers.Add(new Customer(line));
            }
        }

        public static void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
            SaveCustomers();
        }

        public static void SaveCustomers()
        {
            File.WriteAllLines(filePath, Customers.Select(c => c.ToString()));
        }

        public static List<Customer> GetAll() => Customers;
    }

}
