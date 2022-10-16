using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stub
{
    public class StubBonus
    {

        internal Bonus ChargerListeBonusMoyen()
        {
            return Bonus.PetitAuBoutDoublePoignee;
        }

        internal Bonus ChargerListeBonusBien()
        {
            return Bonus.PetitLe21ExcuseSimplePoignee;
        }

        internal Bonus ChargerListeBonusUnSeul()
        {
            return Bonus.Excuse;
        }

    }
}
