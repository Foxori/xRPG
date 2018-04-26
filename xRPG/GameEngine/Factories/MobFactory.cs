using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Factories
{
    public static class MobFactory
    {
        public static Mob GetMob(int mobId)
        {
            switch (mobId)
            {
                case 1:
                    Mob GoblinThief = new Mob("Goblin thief", 5, 5, "Goblin.png", 5, 1, 2, 0);
                    AddMobLootItem(GoblinThief, 1001, 50);
                    AddMobLootItem(GoblinThief, 1002, 50);
                    return GoblinThief;
                case 2:
                    Mob GoblinGuard = new Mob("Goblin guard", 8, 8, "GoblinWithShield.png", 10, 1, 3, 1);
                    AddMobLootItem(GoblinGuard, 1001, 75);
                    AddMobLootItem(GoblinGuard, 1002, 25);
                    return GoblinGuard;
                case 3:
                    Mob DesertBoar = new Mob("Desert Boar", 10, 10, "poshu.png", 15, 5, 3, 2);
                    AddMobLootItem(DesertBoar, 2001, 75);
                    AddMobLootItem(DesertBoar, 2002, 25);
                    return DesertBoar;
                case 4:
                    Mob ProfitSnek = new Mob("Mighty Money Snake", 1000, 1000, "rahamato.png", 1000, 9001, 600, 200);
                    AddMobLootItem(ProfitSnek, 3001, 99);
                    AddMobLootItem(ProfitSnek, 3002, 1);
                    return ProfitSnek;
                case 5:
                    Mob Skeleton = new Mob("Spooky Skeletal", 9001, 9001, "Spoopy.png", 1, 1, 0, 0);
                    AddMobLootItem(Skeleton, 4001, 99);
                    return Skeleton;
                default:
                    throw new ArgumentException(string.Format("Mobtype {0} does not exist", mobId));

            }
        }

        private static void AddMobLootItem(Mob mob, int itemId, int dropPercentage)
        {
            if(RandomNumGen.NumBetween(1, 100) <= dropPercentage)
            {
                mob.MobInventory.Add(new ItemQuantity(itemId, 1));
            }
        }
    }
}
