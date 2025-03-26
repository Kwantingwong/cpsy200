namespace cpsy200.Data
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string Notes { get; set; } // Added property for Notes

        public Category() { }

        // Constructor for parsing data, with optional Notes
        public Category(string line)
        {
            try
            {
                var parts = line.Split(',');

                // Require at least 3 parts (ID, Name, Description)
                if (parts.Length < 3)
                {
                    throw new ArgumentException("Invalid data format.");
                }

                CategoryID = int.Parse(parts[0].Trim());
                CategoryName = parts[1].Trim();
                CategoryDescription = parts[2].Trim();
                Notes = parts.Length > 3 ? parts[3].Trim() : string.Empty; // Notes is optional
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error parsing Category data: {ex.Message}", ex);
            }
        }

        // Constructor to directly create a Category object with Notes
        public Category(int categoryID, string categoryName, string categoryDescription, string notes)
        {
            CategoryID = categoryID;
            CategoryName = categoryName ?? throw new ArgumentNullException(nameof(categoryName));
            CategoryDescription = categoryDescription ?? throw new ArgumentNullException(nameof(categoryDescription));
            Notes = notes ?? string.Empty;
        }

        public override string ToString() => $"{CategoryID},{CategoryName},{CategoryDescription},{Notes}";
    }
}