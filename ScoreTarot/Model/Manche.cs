using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Manche
    {
        public Contrat Contrat{ get; set; }
        public List<Bonus> Bonus { get; set; }
        public Joueur JoueurQuiPrend { get; set; }
        public int Score { get; set; }
        public Date Date { get; set; }

        public Manche(Contrat contrat, List<Bonus> bonus, Joueur joueurQuiPrend, global::System.Int32 score, Date date)
        {
            this.Contrat = contrat;
            this.Bonus = bonus;
            this.JoueurQuiPrend = joueurQuiPrend;
            this.Score = score;
            this.Date = date;
        }

    }
}
