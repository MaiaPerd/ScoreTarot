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
                return pseudo;
            }
            set
            {
                pseudo = value;
                if(String.IsNullOrEmpty(pseudo))
                {
                    throw new ArgumentNullException("value");
                }
            }
        }
        private String pseudo;

        public string Nom { get; private set; }

        public string Prenom { get; private set; } 

        public int Age { get; private set; }

        /**
         *  Url qui permet de retrouver l'image de l'avatar dans le dossier correspondant
         */
        public string URLIMG { get; private set; }

        public Joueur(int id, string pseudo, int age, string nom, string prenom, string nomImage)
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

        public Joueur(string pseudo, int age, string nom, string prenom, string nomImage )
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

        public Joueur(string pseudo, int age, string nom, string prenom)
        {
            if (String.IsNullOrEmpty(pseudo))
            {
                throw new ArgumentNullException(nameof(pseudo));
            }
            Pseudo = pseudo;
            Nom = nom;
            Prenom = prenom;
            Age = age;
            URLIMG = "../image/imageParDefaut.jpeg";
        }

        public Joueur(string pseudo, int age)
        {
            if (String.IsNullOrEmpty(pseudo))
            {
                throw new ArgumentNullException(nameof(pseudo));
            }
            Pseudo = pseudo;
            Nom = "";
            Prenom = "";
            Age = age;
            URLIMG = "../image/imageParDefaut.jpeg";
        }

        public Joueur( string pseudo, int age, string nomImage)
        {
            if (String.IsNullOrEmpty(pseudo))
            {
                throw new ArgumentNullException(nameof(pseudo));
            }
            Pseudo = pseudo;
            Nom = "";
            Prenom = "";
            Age = age;
            URLIMG = "../image/" + nomImage;
        }


        public bool Equals(Joueur autreJoueur)
        {
            return autreJoueur.Pseudo.Equals(pseudo) 
                || autreJoueur.Id.Equals(Id);
        }

        public override bool Equals(object? obj)
        {
            if(ReferenceEquals(null, obj)) { return false; }
            if(ReferenceEquals(this, obj)) { return true; }
            if(obj.GetType() != GetType()) { return false; }
            return Equals(obj as Joueur);
        }
    }
}
