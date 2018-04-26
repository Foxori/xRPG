using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Factories
{
    public static class TraderFactory
    {
        private static readonly List<Trader> traders = new List<Trader>();

        static TraderFactory()
        {
            Trader shop = new Trader("Koju");
            shop.AddItemToTraderInventory(ItemFactory.CreateItem(003));

            AddTraderToList(shop);
        }
        public static Trader GetTraderByName(string traderName)
        {
            return traders.FirstOrDefault(t => t.TraderName == traderName);
        }
        private static void AddTraderToList(Trader trader)
        {
            if(traders.Any(t => t.TraderName == trader.TraderName))
            {
                throw new ArgumentException($"There is already trader who is named {trader.TraderName}");
            }

            traders.Add(trader);
        }
    }
}
