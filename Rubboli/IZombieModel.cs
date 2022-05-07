using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombies
{
    public interface IZombieModel
    {
        void Update();

       // void Walls { set; }
        
       // void SpawnPoints { set; }
        
       // void Player { set; }

        //void LinkScore(Score score);

        int ZombiesToSpawn { set; }

    }
}