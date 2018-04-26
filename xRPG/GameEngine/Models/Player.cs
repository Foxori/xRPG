using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Models
{
    public class Player : BaseNotification
    {
        
        private string nickName;
        private string charClass;
        private int healthPoints;
        private int experience;
        private int level;
        private int goldPieces;
        

        public string NickName
        {
            get { return nickName; }
            set
            {
                nickName = value;
                OnPropertyChanged(nameof(NickName));
            }
        }
        public string CharClass
        {
            get { return charClass; }
            set
            {
                charClass = value;
                OnPropertyChanged(nameof(CharClass));
            }
        }
        public int HealthPoints
        {
            get { return healthPoints; }
            set
            {
                healthPoints = value;
                OnPropertyChanged(nameof(HealthPoints));
            }

        }
        public int Experience
        {
            get { return experience; }
            set
            {
                experience = value;
                OnPropertyChanged(nameof(Experience));

            }
        }
        public int Level
        {
            get { return level; }
            set
            {
                level = value;
                OnPropertyChanged(nameof(Level));
            }
        }
        public int GoldPieces
        {
            get { return goldPieces; }
            set
            {
                goldPieces = value;
                OnPropertyChanged(nameof(GoldPieces));
            }
        }

        public ObservableCollection<Item> PlayerInventory { get; set; }

        public List<Item> Weapons =>
            PlayerInventory.Where(i => i is Weapon).ToList();

        public ObservableCollection<QuestStatus> PlayerQuests { get; set; }

        public Player()
        {
            PlayerInventory = new ObservableCollection<Item>();
            PlayerQuests = new ObservableCollection<QuestStatus>();
        }

        //Lisätään weaponit ja huomautetaan pelaajan saaneen uusia aseita
        public void AddItemToInventory (Item item)
        {
            PlayerInventory.Add(item);

            OnPropertyChanged(nameof(Weapons));
        }

        public void RemoveQuestItemFromInventory(Item item)
        {
            PlayerInventory.Remove(item);

            OnPropertyChanged(nameof(Weapons));

        }

        public bool HasAllQuestItems(List<ItemQuantity> items)
        {
            foreach (ItemQuantity item in items)
            {
                if(PlayerInventory.Count(i => i.ItemTypeId == item.ItemId) < item.Quantity)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
