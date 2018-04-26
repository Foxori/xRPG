using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace GameEngine.Models
{
   public class Trader : BaseNotification
    {
        public string TraderName { get; set; }

        public ObservableCollection<Item> TraderInventory { get; set; }

        public Trader (string traderName)
        {
            TraderName = traderName;
            TraderInventory = new ObservableCollection<Item>();
        }
        public void AddItemToTraderInventory(Item item)
        {
            TraderInventory.Add(item);

        }
        public void RemoveItemFromTraderInventory(Item item)
        {
            TraderInventory.Remove(item);
        }
    }
}
