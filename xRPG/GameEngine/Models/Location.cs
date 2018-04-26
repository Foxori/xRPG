using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Factories;

namespace GameEngine.Models
{
    public class Location
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string PlaceName { get; set; }
        public string PlaceDescription { get; set; }
        public string ImgName { get; set; }
        public List<Quest> QuestsAvailableHere { get; set; } = new List<Quest>();

        public List<MobEncounter> MobsHere { get; set; } = new List<MobEncounter>();
        
        public Trader TraderHere { get; set; }
       
        public void AddMob(int mobId, int changeOfEncounteringMob)
        {
            if(MobsHere.Exists(m => m.MobId == mobId))
            {
                //mobi on jo lisätty tähän sijaintiin
                //ylikirjoita siis ChangeofEncountering uudella arvolla
                MobsHere.First(m => m.MobId == mobId).ChangeOfEncounteringMob = changeOfEncounteringMob;

            }
            else
            {
                //mobia ei vielä ole tässä sijainnissa. Lisätään..
                MobsHere.Add(new MobEncounter(mobId, changeOfEncounteringMob));
            }
        }
        public Mob GetMob()
        {
            if (!MobsHere.Any())
            {
                return null;
            }

            //lasketaan yhteen prosentit kaikista sijainnissa olevista mobeista.
            int totalChances = MobsHere.Sum(m => m.ChangeOfEncounteringMob);

            //valitse random luku 1 ja totalChanges väliltä jos totalchanges ei ole 100
            int randomNumber = RandomNumGen.NumBetween(1, totalChances);

            //loopataan mobi listan läpi
            //lisätään mobin ilmestymisprosentti runningTotaliin
            //arvotun numeron ollessa pienempi kuin runningTotal palautetaan kyseinen mobi
            int runningTotal = 0;

            foreach(MobEncounter mobEncounter in MobsHere)
            {
                runningTotal += mobEncounter.ChangeOfEncounteringMob;

                if(randomNumber <= runningTotal)
                {
                    return MobFactory.GetMob(mobEncounter.MobId);
                }
            }
            //mikäli on ilmenee ongelmia palautetaan edellinen mobi
            return MobFactory.GetMob(MobsHere.Last().MobId);
        }
    }
}
