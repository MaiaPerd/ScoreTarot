using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Joueur
    {
        public int Id { get; private set; }

        public string Pseudo { 
            get
            {
                return Pseudo;
            }
            set
            {
                if(value == null)
                {
                    throw new ArgumentNullException("value");
                }
            }
        }

        public string Nom { get; private set; }

        public string Prenom { get; private set; } 

        public int Age { get; private set; }

        /**
         *  Url qui permet de retrouver l'image de l'avatar dans le dossier correspondant
         */
        public string URLIMG { get; private set; }

        public Joueur(int id, string pseudo, int age, string nom = null, string prenom = null, string nomImage = null)
        {
            if (String.IsNullOrEmpty(pseudo))
            {
                throw new ArgumentNullException(nameof(pseudo));
            }
            Id = id;
            Pseudo = pseudo;
            Nom = nom;
            Prenom = prenom;
            Age = age;
            URLIMG = "../image/" + nomImage;
        }

        public Joueur(string pseudo, int age, string nom = null, string prenom = null, string nomImage = null)
        {
            if (String.IsNullOrEmpty(pseudo))
            {
                throw new ArgumentNullException(nameof(pseudo));
            }
            Pseudo = pseudo;
            Nom = nom;
            Prenom = prenom;
            Age = age;
            URLIMG = "../image/" + nomImage;
        }

    }
}
