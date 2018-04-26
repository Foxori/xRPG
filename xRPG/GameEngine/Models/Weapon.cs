using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Models
{
    public class Weapon : Item
    {
        public int MinDmg { get; set; }
        public int MaxDmg { get; set; }

        public Weapon(int itemTypeId, string itemName, int itemValue, int minDmg, int maxDmg) : base(itemTypeId, itemName, itemValue)
        {
            MinDmg = minDmg;
            MaxDmg = maxDmg;
        }
        public new Weapon Clone()
        {
            return new Weapon(ItemTypeId, ItemName, ItemValue, MinDmg, MaxDmg);
        }
    }
}
