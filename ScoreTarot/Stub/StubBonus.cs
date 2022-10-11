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

        internal List<Bonus> ChargerListeBonusMoyen()
        {
            List<Bonus> lBonus =  new List<Bonus>();
            lBonus.Add(Bonus.PetitAuBout);
            lBonus.Add(Bonus.Petit);
            lBonus.Add(Bonus.DoublePoignee);
            return lBonus;
        }

        internal List<Bonus> ChargerListeBonusBien()
        {
            List<Bonus> lBonus = new List<Bonus>();
            lBonus.Add(Bonus.Escuse);
            lBonus.Add(Bonus.Petit);
            lBonus.Add(Bonus.Le21);
            lBonus.Add(Bonus.SimplePoignee);
            return lBonus;
        }

        internal List<Bonus> ChargerListeBonusUnSeul()
        {
            List<Bonus> lBonus = new List<Bonus>();
            lBonus.Add(Bonus.Escuse);
            return lBonus;
        }

    }
}
