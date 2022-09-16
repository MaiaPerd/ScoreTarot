using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Manche
    {
        public Contrat Contrat{ get; private set; }
        public List<Bonus> Bonus { get; private set; }
        public Joueur JoueurQuiPrend { get; private set; }

        public Joueur JoueurAllier { get; private set; }
        public int Score{get; private set ; }
        public DateTime Date {get; private set;}
        public int Id { get; private set; }

        public Manche(Contrat contrat, Joueur joueurQuiPrend, int id, int score, List<Bonus> bonus = null)
        {
            Contrat = contrat;
            Bonus = new List<Bonus>();
            Bonus.AddRange(bonus);
            JoueurQuiPrend = joueurQuiPrend;
            Score = score;
            Date = new DateTime();
            
            Id = id;
        }

        public override bool Equals(object? obj)
        {
            return obj is Manche manche &&
                   Id == manche.Id;
        }
    }
}
