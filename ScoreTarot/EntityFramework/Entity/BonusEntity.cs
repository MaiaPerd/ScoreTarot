using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Entity
{
    [Flags]
    public enum BonusEntity : Byte
    {
        Inconu = 0,
        PetitAuBout = 1,
        SimplePoignee = 2,
        DoublePoignee = 4,
        TriplePoignee = 8,
        Petit = 16,
        Excuse = 32,
        Le21= 64,


        //Toutes les combinaisons posible :

        #region Petit et poignee
        PetitSimplePoignee = Petit | SimplePoignee,
        PetitAuBoutSimplePoignee = Petit | PetitAuBout | SimplePoignee,
        PetitDoublePoignee = Petit | DoublePoignee,
        PetitAuBoutDoublePoignee = Petit | PetitAuBout | DoublePoignee,
        PetitTriplePoignee = Petit | TriplePoignee,
        PetitAuBoutTriplePoignee = Petit | PetitAuBout | TriplePoignee,
        #endregion

        #region Excuse et poignee
        ExcuseSimplePoignee = Excuse | SimplePoignee,
        ExcuseDoublePoignee = Excuse | DoublePoignee,
        ExcuseTriplePoignee = Excuse | TriplePoignee,
        #endregion

        #region Le21 et poignee
        Le21SimplePoignee = Le21 | SimplePoignee,
        Le21DoublePoignee = Le21 | DoublePoignee,
        Le21TriplePoignee = Le21 | TriplePoignee,
        #endregion

        #region Petit et Excuse et poignee
        PetitExcuse = Petit | Excuse,
        PetitAuBoutExcuse = Petit | PetitAuBout | Excuse,
        PetitExcuseSimplePoignee = Petit | Excuse | SimplePoignee,
        PetitAuBoutExcuseSimplePoignee = Petit | PetitAuBout | Excuse | SimplePoignee,
        PetitExcuseDoublePoignee = Petit | Excuse | DoublePoignee,
        PetitAuBoutExcuseDoublePoignee = Petit | PetitAuBout | Excuse | DoublePoignee,
        PetitExcuseTriplePoignee = Petit | Excuse | TriplePoignee,
        PetitAuBoutExcuseTriplePoignee = Petit | PetitAuBout | Excuse | TriplePoignee,
        #endregion

        #region Petit et Le21 et poignee
        PetitLe21 = Petit | Le21,
        PetitAuBoutLe21 = Petit | PetitAuBout | Le21,
        PetitLe21SimplePoignee = Petit | Le21 | SimplePoignee,
        PetitAuBoutLe21SimplePoignee = Petit | PetitAuBout | Le21 | SimplePoignee,
        PetitLe21DoublePoignee = Petit | Le21 | DoublePoignee,
        PetitAuBoutLe21DoublePoignee = Petit | PetitAuBout | Le21 | DoublePoignee,
        PetitLe21TriplePoignee = Petit | Le21 | TriplePoignee,
        PetitAuBoutLe21TriplePoignee = Petit | PetitAuBout | Le21 | TriplePoignee,
        #endregion

        #region Petit et Le21 et Excuse et poignee
        PetitLe21Excuse = Petit | Le21 | Excuse,
        PetitAuBoutLe21Excuse = Petit | PetitAuBout | Le21 | Excuse,
        PetitLe21ExcuseSimplePoignee = Petit | Le21 | Excuse | SimplePoignee,
        PetitAuBoutLe21ExcuseSimplePoignee = Petit | PetitAuBout | Le21 | Excuse | SimplePoignee,
        PetitLe21ExcuseDoublePoignee = Petit | Le21 | Excuse | DoublePoignee,
        PetitAuBoutLe21ExcuseDoublePoignee = Petit | PetitAuBout | Le21 | Excuse | DoublePoignee,
        PetitLe21ExcuseTriplePoignee = Petit | Le21 | Excuse | TriplePoignee,
        PetitAuBoutLe21ExcuseTriplePoignee = Petit | PetitAuBout | Le21 | Excuse | TriplePoignee,
        #endregion

        #region Le21 et Excuse et poignee
        Le21Excuse = Excuse | Le21,
        Le21ExcuseSimplePoignee = Le21 | Excuse | SimplePoignee,
        Le21ExcuseDoublePoignee = Le21 | Excuse | DoublePoignee,
        Le21ExcuseTriplePoignee = Le21 | Excuse | TriplePoignee,
        #endregion

    }
}
