using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Partie
    {
        public List<Joueur> Joueurs
        {
            get;

            private set;
        }
        public List<Manche> Manches { get; private set; }
        public int Id { get; private set; }

        public Partie(List<Joueur> joueurs, List<Manche> manches, int id)
        {

            Joueurs = new List<Joueur>();
            Joueurs.AddRange(joueurs);
            
            Manches= new List<Manche>();
            Manches.AddRange(manches);
            Id = id;
        }

        public Partie(List<Joueur> joueurs, List<Manche> manches)
        {

            Joueurs = new List<Joueur>();
            Joueurs.AddRange(joueurs);

            Manches = new List<Manche>();
            Manches.AddRange(manches);
        }

        public void AjouterManche(Manche manche)
        {
            Manches.Add(manche);
            
        }

        public override bool Equals(object? obj)
        {
            return obj is Partie partie &&
                   Id == partie.Id;
        }
        
        
        
    }
}
