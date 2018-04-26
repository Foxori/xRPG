using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Models
{
    public class MobEncounter
    {
        public int MobId { get; set; }
        public int ChangeOfEncounteringMob { get; set; }

        public MobEncounter(int mobId, int channgeOfEncounteringMob)
        {
            MobId = mobId;
            ChangeOfEncounteringMob = channgeOfEncounteringMob;
        }
    }
}
