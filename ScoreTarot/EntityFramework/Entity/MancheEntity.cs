using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Entity
{
    public class MancheEntity
    {
        public ContratEntity Contrat { get;  set; }
        public List<BonusEntity> Bonus { get;  set; }
        public JoueurEntity JoueurQuiPrend { get; set; }
        public JoueurEntity JoueurAllier { get;  set; }
        public int Score { get; set; }
        public DateTime Date { get;  set; }
        public int Id { get;  set; }
        public int NbJoueur { get;  set; }

    }
}
