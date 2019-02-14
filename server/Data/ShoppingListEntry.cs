using System;

namespace GrokGroceries.Data
{

    public class ShoppingListEntry
    {
        public Guid Uuid { get; set; }

        public GroceryItem Item { get; set; }

        public long Quantity { get; set; }
    }
}