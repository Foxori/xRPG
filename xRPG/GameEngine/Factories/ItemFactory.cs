using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Models;

namespace GameEngine.Factories
{
    public static class ItemFactory
    {
        private static readonly List<Item> _defaultItems = new List<Item>();

        static ItemFactory()
        {
            _defaultItems.Add(new Weapon(003, "Sword", 20, 0, 7));
            _defaultItems.Add(new Weapon(001, "Butter knife", 5, 0, 3));
            _defaultItems.Add(new Item(1001, "Goblin mail", 2));
            _defaultItems.Add(new Item(1002, "Torn cloth", 1));
            _defaultItems.Add(new Item(2001, "Boar skin", 5));
            _defaultItems.Add(new Item(2002, "Boar tooth", 10));
            _defaultItems.Add(new Item(3001, "Snake skin", 900));
            _defaultItems.Add(new Item(3002, "Little Snakeling", 0));
            _defaultItems.Add(new Item(4001, "Trumpet", 0));
            _defaultItems.Add(new Weapon(002, "Broken Sword", 10, 0, 5));
           
            _defaultItems.Add(new Weapon(999, "Thunderfury", 0, 1000, 1000));

        }
        public static Item CreateItem(int itemTypeID)
        {
            Item defaultItems = _defaultItems.FirstOrDefault(item => item.ItemTypeId == itemTypeID);

            if (defaultItems != null)
            {
                if (defaultItems is Weapon)
                {
                    return (defaultItems as Weapon).Clone();
                }

                return defaultItems.Clone();
            }
            return null;
        }
    }
}
