using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Models;

namespace GameEngine.Factories
{
    internal static class WorldFactory
    {
        internal static World CreateWorld()
        {
            World newWorld = new World();

            newWorld.AddLocation(0, 0, "Spawn", "Good place to start an adventure from.", "Spawn.png");

            newWorld.AddLocation(1, -1, "Goblin Village", "Place where goblins live", "Goblinikyla.png");

            newWorld.PlayerAt(1, -1).AddMob(1, 50);
            newWorld.PlayerAt(1, -1).AddMob(2, 50);

            newWorld.AddLocation(1, 0, "Forest", "There are trees everywhere", "meha.png");

            newWorld.AddLocation(2, 0, "Black Knight Fortress entrance", "Black Knights live here", "Turunlinna.png");

            newWorld.PlayerAt(2, 0).QuestsAvailableHere.Add(QuestFactory.GetQuestById(1));

            newWorld.AddLocation(3, 0, "Black market", "All sorts of deals get made in here", "koju.png");
            newWorld.PlayerAt(3, 0).TraderHere = TraderFactory.GetTraderByName("Koju");

            newWorld.AddLocation(2, 1, "Desert", "It is really hot in here", "jonkinsortin_aavikko.png");
            newWorld.PlayerAt(2, 1).AddMob(3, 50);
            newWorld.AddLocation(2, 2, "More Desert", "It is still really hot in here", "jonkinsortin_aavikko.png");
            newWorld.PlayerAt(2, 2).AddMob(3, 50);
            newWorld.AddLocation(2, 3, "Even More Desert", "It is not so hot in here", "jonkinsortin_aavikko.png");
            newWorld.PlayerAt(2, 3).AddMob(3, 50);
            newWorld.AddLocation(3, 3, "Forest road", "Finally out of that Desert", "kallio.png");
            newWorld.AddLocation(3, 3, "More Forest road", "Still better than that damn desert", "kallio.png");
            newWorld.AddLocation(3, 4, "Sick Forest", "There seems to be something wrong with trees", "syksy_meha.png");
            newWorld.AddLocation(3, 5, "More Sick Forest", "You see a warning sign: DO NOT CONTINUE", "syksy_meha.png");
            newWorld.AddLocation(3, 6, "More Sick Forest", "You see a warning sign: STOP NOW", "syksy_meha.png");
            newWorld.AddLocation(3, 7, "Dead Forest", "TURN BACK PLEASE", "suosta_nousi_mato.png");
            newWorld.AddLocation(3, 8, "More Dead Forest", "YOU ARE GOING TO DIE", "suosta_nousi_mato.png");
            newWorld.AddLocation(3, 9, "More Dead Forest", "NEXT STEP WILL BE YOUR LAST", "suosta_nousi_mato.png");
            newWorld.AddLocation(3, 10, "More Dead Forest", "Well i tried to warn you..", "suosta_nousi_mato.png");
            newWorld.AddLocation(3, 11, "More Dead Forest", "Doot", "suosta_nousi_mato.png");
            newWorld.PlayerAt(3, 11).AddMob(5, 100);
            newWorld.AddLocation(3, 12, "More Dead Forest", "No but really if you continue you will die", "suosta_nousi_mato.png");
            newWorld.AddLocation(3, 13, "More Dead Forest", "Take a seat kid.", "suosta_nousi_mato.png");
            newWorld.PlayerAt(3, 13).AddMob(4, 100);



            return newWorld;
        }
    }
}
