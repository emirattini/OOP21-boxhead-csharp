using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP21_boxhead_csharp.Rattini
{
    public interface IShot
    {
        Boolean HasEnded();

        int Damage { get; }

        ITrajectory GetTrajectory();

        void Update();

    }
}
