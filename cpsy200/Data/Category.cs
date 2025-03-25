using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cpsy200.Data
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public Category(string line)
        {
            var parts = line.Split(',');
            CategoryID = int.Parse(parts[0]);
            CategoryName = parts[1];
            CategoryDescription = parts[2];
        }

        public override string ToString() => $"{CategoryID} - {CategoryName}";
    }
}
