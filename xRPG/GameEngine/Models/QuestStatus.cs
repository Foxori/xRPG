﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Models
{
    public class QuestStatus
    {
        public Quest PlayerQuest { get; set; }
        public bool IsQuestDone { get; set; }

        public QuestStatus(Quest quest)
        {
            PlayerQuest = quest;
            IsQuestDone = false;
        }
    }
}
