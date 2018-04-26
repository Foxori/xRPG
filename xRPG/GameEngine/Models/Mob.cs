using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;

namespace GameEngine.Models
{
    public class Mob : BaseNotification
    {
        private int mobHp;

        public string MobName { get; private set; }
        public int MobMaxHp { get; private set; }
        public string MobImgName { get; set; }
        public int MobHp
        {
            get { return mobHp; }
            set
            {
                mobHp = value;
                OnPropertyChanged(nameof(MobHp));
            }
        }
        public int MobMaxHit { get; set; }
        public int MobMinHit { get; set; }

        public int KillRewardXp { get; private set; }
        public int KillRewardGoldPieces { get; private set; }

        public ObservableCollection<ItemQuantity> MobInventory { get; set; }

        public Mob(string mobName, int mobMaxHp, int mobHp, string mobImgName, int killRewardXp, int killRewardGoldPieces, int mobMaxHit, int mobMinHit)
        {
            MobName = mobName;
            MobMaxHp = mobMaxHp;
            MobHp = mobHp;
            MobImgName = $"/GameEngine;component/Img/NPCImg/{mobImgName}";
            KillRewardXp = killRewardXp;
            KillRewardGoldPieces = killRewardGoldPieces;
            MobMaxHit = mobMaxHit;
            MobMinHit = mobMinHit;

            MobInventory = new ObservableCollection<ItemQuantity>();
        }
    }
}
