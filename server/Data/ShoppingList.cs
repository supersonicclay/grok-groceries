using System;
using System.Collections.Generic;
using System.Linq;

namespace GrokGroceries.Data
{
    public class ShoppingList
    {
        private List<GroceryItem> items = new List<GroceryItem>();

        private List<ShoppingListEntry> entries = new List<ShoppingListEntry>();

        public ShoppingListEntry[] GetAll()
        {
            return entries.ToArray();
        }

        public ShoppingListEntry AddEntry(Guid itemUuid)
        {
            ShoppingListEntry entry = entries.Find(e => e.Item.Uuid == itemUuid);
            if (entry != null)
            {
                entry.Quantity = entry.Quantity + 1;
            }
            else
            {
                var item = items.First(i => i.Uuid == itemUuid);
                entry = new ShoppingListEntry
                {
                    Uuid = Guid.NewGuid(),
                    Item = item,
                    Quantity = 1
                };
                entries.Add(entry);
            }
            return entry;
        }

        public ShoppingListEntry AddEntry(string name)
        {
            Guid itemUuid;

            var existingItem = items.Find(i => i.Name == name);
            if (existingItem != null)
            {
                itemUuid = existingItem.Uuid;
            }
            else
            {
                itemUuid = Guid.NewGuid();
                items.Add(new GroceryItem
                {
                    Uuid = itemUuid,
                    Name = name,
                    Occurrence = 1
                });
            }

            return AddEntry(itemUuid);
        }

        // Yay for prototypes!
        private static ShoppingList instance;
        public static ShoppingList Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ShoppingList();
                    instance.AddEntry("milk");
                    instance.AddEntry("eggs");
                    instance.AddEntry("cheese");
                    instance.AddEntry("eggs");
                }
                return instance;
            }
        }

    }
}