using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Models;
using GameEngine.Factories;
using System.ComponentModel;
using GameEngine.EventArgs;

namespace GameEngine.ViewModels
{
    public class Session : BaseNotification
    {
       public event EventHandler<GameMessageEventArgs> OnMessageRaised;
       private Location playerLocation;
       private Mob currentMob;
       private Trader currentTrader;
       public World PlayerWorld { get; set; }
       public Player StandardPlayer { get; set; }
       public Location PlayerLocation
        {
            get { return playerLocation; }
            set
            {
                playerLocation = value;
                OnPropertyChanged(nameof(PlayerLocation));
                OnPropertyChanged(nameof(CanMoveUp));
                OnPropertyChanged(nameof(CanMoveDown));
                OnPropertyChanged(nameof(CanMoveLeft));
                OnPropertyChanged(nameof(CanMoveRight));

                CompleteQuestsHere();
                GiveStandardPlayerQuestsHere();
                GetMobAtLocation();
                CurrentTrader = PlayerLocation.TraderHere;
            }
        }
        public Trader CurrentTrader
        {
            get { return currentTrader;}
            set
            {
                currentTrader = value;
                OnPropertyChanged(nameof(CurrentTrader));
                OnPropertyChanged(nameof(HasTrader));
            }
        }
        public Weapon CurrentWeapon { get; set; }
        public bool CanMoveUp
        {
            get
            {
                return PlayerWorld.PlayerAt(PlayerLocation.XCoordinate, PlayerLocation.YCoordinate + 1) != null;
            }
        }

        public Mob CurrentMob
        {
            get { return currentMob; }
            set
            {
                currentMob = value;
                OnPropertyChanged(nameof(CurrentMob));
                OnPropertyChanged(nameof(HasMob));

                if (CurrentMob != null)
                {
                    RaiseMessage("");
                    RaiseMessage($"You encounter {CurrentMob.MobName}!");
                }
            }
        }
        public bool CanMoveDown
        {
            get
            {
                return PlayerWorld.PlayerAt(PlayerLocation.XCoordinate, PlayerLocation.YCoordinate - 1) != null;
            }
        }
        public bool CanMoveLeft
        {
            get
            {
                return PlayerWorld.PlayerAt(PlayerLocation.XCoordinate - 1, PlayerLocation.YCoordinate) != null;
            }
        }
        public bool CanMoveRight
        {
            get
            {
                return PlayerWorld.PlayerAt(PlayerLocation.XCoordinate + 1, PlayerLocation.YCoordinate) != null;
            }
        }

        public bool HasMob => CurrentMob != null;

        public bool HasTrader => CurrentTrader != null;

        public Session()
        {
            StandardPlayer = new Models.Player
            {
                NickName = "Aaro236",
                CharClass = "Warrior",
                Experience = 0,
                GoldPieces = 0,
                HealthPoints = 10,
                Level = 1

            };
            if (!StandardPlayer.Weapons.Any())
            {
                StandardPlayer.AddItemToInventory(ItemFactory.CreateItem(001));
            }

            PlayerWorld = WorldFactory.CreateWorld();
            PlayerLocation = PlayerWorld.PlayerAt(0, 0);

           
        }
        public void MoveUp()
        {
            if (CanMoveUp)
            {
                PlayerLocation = PlayerWorld.PlayerAt(PlayerLocation.XCoordinate, PlayerLocation.YCoordinate + 1);
            }
            
        }
        public void MoveDown()
        {
            if (CanMoveDown)
            {
                PlayerLocation = PlayerWorld.PlayerAt(PlayerLocation.XCoordinate, PlayerLocation.YCoordinate - 1);
            }
        }
        public void MoveLeft()
        {
            if (CanMoveLeft)
            {
                PlayerLocation = PlayerWorld.PlayerAt(PlayerLocation.XCoordinate - 1, PlayerLocation.YCoordinate);
            }
        }
        public void MoveRight()
        {
            if (CanMoveRight)
            {
                PlayerLocation = PlayerWorld.PlayerAt(PlayerLocation.XCoordinate + 1, PlayerLocation.YCoordinate);
            }
          
        }

        private void CompleteQuestsHere()
        {
            foreach (Quest quest in PlayerLocation.QuestsAvailableHere)
            {
                QuestStatus questToComplete = StandardPlayer.PlayerQuests.FirstOrDefault(q => q.PlayerQuest.QuestId == quest.QuestId && !q.IsQuestDone);
                if (questToComplete != null)
                {
                    if (StandardPlayer.HasAllQuestItems(quest.QuestItemsToComplete))
                    {
                        //poistetaan questi itemit pelaajalta
                        foreach (ItemQuantity itemQuantity in quest.QuestItemsToComplete)
                        {
                            for (int i = 0; i < itemQuantity.Quantity; i++)
                            {
                                StandardPlayer.RemoveQuestItemFromInventory(StandardPlayer.PlayerInventory.First(item => item.ItemTypeId == itemQuantity.ItemId));
                            }
                        }
                        RaiseMessage("");
                        RaiseMessage($"You have completed the {quest.QuestName} quest.");
                        //annetaan questi palkinnot
                        StandardPlayer.Experience += quest.QuestRewardXP;
                        RaiseMessage($"You receive {quest.QuestRewardXP} experience");
                        StandardPlayer.GoldPieces += quest.QuestRewardGoldPieces;
                        RaiseMessage($"You receive {quest.QuestRewardGoldPieces} Gold Pieces");
                        foreach (ItemQuantity itemQuantity in quest.QuestRewardItems)
                        {
                            Item rewardItem = ItemFactory.CreateItem(itemQuantity.ItemId);
                            StandardPlayer.AddItemToInventory(rewardItem);
                            RaiseMessage($"You receive {rewardItem.ItemName}");
                        }
                        //merkataan questi tehdyksi
                        questToComplete.IsQuestDone = true;
                    }
                }
            }

        }

        private void GiveStandardPlayerQuestsHere()
        {
            foreach (Quest quest in PlayerLocation.QuestsAvailableHere)
            {
                //tarkistetaan onko pelaaja suorittanut jo questin jos ei niin annetaan pelaajalle questi
                if(!StandardPlayer.PlayerQuests.Any(q => q.PlayerQuest.QuestId == quest.QuestId))
                {
                    StandardPlayer.PlayerQuests.Add(new QuestStatus(quest));
                    RaiseMessage("");
                    RaiseMessage($"You receive {quest.QuestName} quest");
                    RaiseMessage(quest.QuestDescription);

                    RaiseMessage("Return with:");
                    foreach(ItemQuantity itemQuantity in quest.QuestItemsToComplete)
                    {
                        RaiseMessage($"{itemQuantity.Quantity } {ItemFactory.CreateItem(itemQuantity.ItemId).ItemName }");
                    }
                    RaiseMessage("You will receive:");
                    RaiseMessage($" {quest.QuestRewardGoldPieces} gold pieces. ");
                    RaiseMessage($"{quest.QuestRewardXP} experience.");
                    foreach(ItemQuantity itemQuantity in quest.QuestRewardItems)
                    {
                        RaiseMessage($"{itemQuantity.Quantity} {ItemFactory.CreateItem(itemQuantity.ItemId).ItemName}");
                    }

                }
            }
        }


        private void GetMobAtLocation()
        {
            CurrentMob = PlayerLocation.GetMob();
        }

        private void RaiseMessage(string message)
        {
            OnMessageRaised?.Invoke(this, new GameMessageEventArgs(message));
        }
        public void AttackCurrentMob()
        {
            if (CurrentWeapon == null)
            {
                RaiseMessage("Please select a weapon to attack mob.");
                return;
            }

            //Määritetään pelaajan hyökkäyksen voimakkuus mobia kohtaan
            int damageToMob = RandomNumGen.NumBetween(CurrentWeapon.MinDmg, CurrentWeapon.MaxDmg);
            if (damageToMob == 0)
            {
                RaiseMessage($"{CurrentMob.MobName} dodges your attack.");
            }
            else
            {
                CurrentMob.MobHp -= damageToMob;
                RaiseMessage($"You hit {CurrentMob.MobName} for {damageToMob} damage.");
            }
            //Mobin kuoleman tarkistus ja tavaroiden anto pelaajalle
            if (CurrentMob.MobHp <= 0)
            {
                StandardPlayer.Level = StandardPlayer.Experience / 10 + 1;
                RaiseMessage("");
                RaiseMessage($"You have killed the {CurrentMob.MobName}");

                StandardPlayer.Experience += CurrentMob.KillRewardXp;
                RaiseMessage($"You receive {CurrentMob.KillRewardXp} experience.");

                StandardPlayer.GoldPieces += CurrentMob.KillRewardGoldPieces;
                RaiseMessage($"You loot {CurrentMob.KillRewardGoldPieces} gold pieces.");
                foreach(ItemQuantity itemQuantity in CurrentMob.MobInventory)
                {
                    Item _item = ItemFactory.CreateItem(itemQuantity.ItemId);
                    StandardPlayer.AddItemToInventory(_item);
                    RaiseMessage($"You loot {itemQuantity.Quantity} {_item.ItemName}.");
                }
                //spawnataan toinen mobi tapettavaksi
                GetMobAtLocation();
            }
            else
            {
                //jos mobi on vielä elossa annetaan sen lyödä
                int damageToPlayer = RandomNumGen.NumBetween(CurrentMob.MobMinHit, CurrentMob.MobMaxHit);

                if(damageToPlayer == 0)
                {
                    RaiseMessage("You dodge mob's attack.");
                }
                else
                {
                    StandardPlayer.HealthPoints -= damageToPlayer;
                    RaiseMessage($"{CurrentMob.MobName} hits you for {damageToPlayer} damage.");
                }

                //Mikäli pelaaja kuolee siirretään hänet takaisin spawniin
                if (StandardPlayer.HealthPoints <= 0)
                {
                    RaiseMessage("");
                    RaiseMessage($"L000000L {CurrentMob.MobName} just PWNED you.");

                    PlayerLocation = PlayerWorld.PlayerAt(0, 0);
                    StandardPlayer.Level = StandardPlayer.Experience / 10 + 1;
                    StandardPlayer.HealthPoints = StandardPlayer.Level * 10;
                    
                }
            }
        }
        
    }
}
