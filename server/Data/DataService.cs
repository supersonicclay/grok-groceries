using System;
using System.Collections.Generic;
using System.Linq;

namespace GrokGroceries.Data
{
    public class DataService
    {
        private List<GroceryItem> items = new List<GroceryItem>();

        private ShoppingList list = new ShoppingList()
        {
            Entries = new List<ShoppingListEntry>(),
            CompletedEntries = new List<ShoppingListEntry>()
        };

        public ShoppingList GetAll()
        {
            return list;
        }

        public ShoppingListEntry AddEntry(Guid itemUuid)
        {
            ShoppingListEntry entry = list.Entries.Find(e => e.Item.Uuid == itemUuid);
            if (entry != null)
            {
                entry.Quantity = entry.Quantity + 1;
            }
            else
            {
                var item = items.Single(i => i.Uuid == itemUuid);
                entry = new ShoppingListEntry
                {
                    Uuid = Guid.NewGuid(),
                    Item = item,
                    Quantity = 1
                };
                list.Entries.Add(entry);
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

        public void CompleteEntry(Guid entryUuid)
        {
            var index = list.Entries.FindIndex(e => e.Uuid == entryUuid);
            if (index == -1)
            {
                return;
            }
            ShoppingListEntry entry = list.Entries[index];
            list.Entries.RemoveAt(index);

            list.CompletedEntries.Insert(0, entry);
        }

        // Yay for prototypes!
        private static DataService instance;
        public static DataService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataService();
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