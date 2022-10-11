using System;
namespace EntityFramework.Entity
{
    public class PartieJoueur
    {
        public PartieEntity Partie { get; set; }
        public JoueurEntity Joueur { get; set; }
    }
}

