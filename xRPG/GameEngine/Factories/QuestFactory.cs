using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Models;

namespace GameEngine.Factories
{
    internal static class QuestFactory
    {
        private static readonly List<Quest> quests = new List<Quest>();
        
        static QuestFactory()
        {
            //määritä itemit joita vaaditaan questin tekemiseen
            List<ItemQuantity> itemsToCompleteQuest = new List<ItemQuantity>();
            //Määritä itemit joita saa questin tekemisestä
            List<ItemQuantity> questRewardItems = new List<ItemQuantity>();

            itemsToCompleteQuest.Add(new ItemQuantity(1001, 5));
            questRewardItems.Add(new ItemQuantity(003, 1));

            //luodaan questi
            quests.Add(new Quest(1,
                                 "Goblin Genocide",
                                 "Kill goblins and bring back 5 Goblins mails",
                                 itemsToCompleteQuest, 25, 10, questRewardItems));
        }

        internal static Quest GetQuestById (int id)
        {
            return quests.FirstOrDefault(quest => quest.QuestId == id);
        }
        

    }
}
