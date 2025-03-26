using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace cpsy200.Data
{
    public static class CategoryManager
    {
        private static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                @"..\..\..\..\Resources\Res\category_list.csv");

        // Method to retrieve all categories from the CSV file
        public static List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();

            try
            {
                // Open the file stream to read the CSV file
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read))
                using (StreamReader sr = new StreamReader(fs))
                {
                    string line;
                    Category category;

                    // Read each line from the file
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            // Create a Category object from the line and add it to the list
                            category = new Category(line);
                            categories.Add(category);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during file reading
                Console.WriteLine($"Error reading category data: {ex.Message}");
            }

            // Return the categories sorted by CategoryID
            return categories.OrderBy(c => c.CategoryID).ToList();
        }

        // Method to add a new category to the file
        public static void AddCategory(Category category)
        {
            try
            {
                // Append the new category to the file
                using (StreamWriter sw = new StreamWriter(filePath, append: true))
                {
                    sw.WriteLine(category.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding new category: {ex.Message}");
            }
        }

        // Additional method to save the list of categories back to the file
        public static void SaveCategories(List<Category> categories)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    foreach (var category in categories)
                    {
                        sw.WriteLine(category.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving categories: {ex.Message}");
            }
        }
    }
}
