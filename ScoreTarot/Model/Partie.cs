using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Partie
    {
        public ArrayList<Joueur> Joueurs { get; set; }
        public ArrayList<Manche> Manches { get; set; }

        public Partie(ArrayList<Joueur> joueurs,ArrayList<Manche> manches)
        {
            this.Joueurs = joueurs;
            this.Manches = manches;
        }

        public void AjouterManche(Manche manche)
        {
            Manches.add(manche);
        }
        public void 
    }
}
