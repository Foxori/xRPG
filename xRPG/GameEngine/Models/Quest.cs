using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Models
{
    public class Quest
    {
        public int QuestId { get; set; }
        public string QuestName { get; set; }
        public string QuestDescription { get; set; }

        public List<ItemQuantity> QuestItemsToComplete { get; set; }

        public int QuestRewardXP { get; set; }
        public int QuestRewardGoldPieces { get; set; }
        public List<ItemQuantity> QuestRewardItems { get; set; }

        public Quest(int questId, string questName, string questDescription, List<ItemQuantity> questItemsToComplete, int questRewardXP, int questRewardGoldPieces, List<ItemQuantity> questRewardItems)
        {
            QuestId = questId;
            QuestName = questName;
            QuestDescription = questDescription;
            QuestItemsToComplete = questItemsToComplete;
            QuestRewardXP = questRewardXP;
            QuestRewardGoldPieces = questRewardGoldPieces;
            QuestRewardItems = questRewardItems;

        }
    }
}
