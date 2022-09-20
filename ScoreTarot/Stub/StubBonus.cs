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

        public List<Bonus> chargerListeBonusMoyen()
        {
            List<Bonus> lBonus =  new List<Bonus>();
            lBonus.Add(Bonus.PetitAuBout);
            lBonus.Add(Bonus.Petit);
            lBonus.Add(Bonus.DoublePoignet);
            return lBonus;
        }

        public List<Bonus> chargerListeBonusBien()
        {
            List<Bonus> lBonus = new List<Bonus>();
            lBonus.Add(Bonus.Escuse);
            lBonus.Add(Bonus.Petit);
            lBonus.Add(Bonus.Le21);
            lBonus.Add(Bonus.SimplePoignet);
            return lBonus;
        }

        public List<Bonus> chargerListeBonusUnSeul()
        {
            List<Bonus> lBonus = new List<Bonus>();
            lBonus.Add(Bonus.Escuse);
            return lBonus;
        }

    }
}
