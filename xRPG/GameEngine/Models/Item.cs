using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Models
{
    public class Item
    {
        public int ItemTypeId { get; set; }
        public string ItemName { get; set; }
        public int ItemValue { get; set; }

        public Item(int itemTypeId, string itemName, int itemValue)
        {
            ItemTypeId = itemTypeId;
            ItemName = itemName;
            ItemValue = itemValue;
        }

        public Item Clone()
        {
            return new Item(ItemTypeId, ItemName, ItemValue);
        }
    }
}
