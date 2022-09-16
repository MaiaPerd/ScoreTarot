using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Joueur
    {

        public string Pseudo { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; } 

        public int Age { get; set; }

        /**
         *  Url qui permet de retrouver l'image de l'avatar
         */
        public string URLIMG { get; set; }

        public Joueur(string pseudo, string nom, string prenom, int age, string uRLIMG)
        {
            Pseudo = pseudo;
            Nom = nom;
            Prenom = prenom;
            Age = age;
            URLIMG = uRLIMG;
        }

    }
}
