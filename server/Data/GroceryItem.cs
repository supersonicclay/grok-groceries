using System;

namespace GrokGroceries.Data
{

    public class GroceryItem
    {
        public Guid Uuid { get; set; }

        public string Name { get; set; }

        public long Occurrence { get; set; }
    }
}