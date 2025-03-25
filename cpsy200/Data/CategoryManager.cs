using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cpsy200.Data
{
    public static class CategoryManager
    {
        private static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                @"..\..\..\..\Resources\Res\category_list.csv");

        public static List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();

            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string line;
            Category category;

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(line))
                {
                    category = new Category(line);
                    categories.Add(category);
                }
            }

            sr.Close();

            return categories.OrderBy(c => c.CategoryID).ToList();
        }

    }
}
