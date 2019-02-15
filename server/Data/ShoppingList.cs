using System;
using System.Collections.Generic;

namespace GrokGroceries.Data
{

    public class ShoppingList
    {
        public List<ShoppingListEntry> Entries { get; set; }

        public List<ShoppingListEntry> CompletedEntries { get; set; }
    }
}