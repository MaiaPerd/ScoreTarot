using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Joueur :IEquatable<Joueur>
    {
        public int Id { get; private set; }
        public string Pseudo { 
            get
            {
                return pseudo;
            }
            private set
            {
                pseudo = value;
                if(String.IsNullOrEmpty(pseudo))
                {
                    throw new ArgumentNullException("Le pseudo ne peut pas être null, n'y vide");
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

        /// <summary>
        /// Constructeur du joueur avec toutes les données possible.
        /// </summary>
        /// <param name="pseudo"></param> identifiant du joueur, le pseudo est unique
        /// <param name="age"></param> age du joueur
        /// <param name="nom"></param> nom du joueur
        /// <param name="prenom"></param> prenom du joueur 
        /// <param name="nomImage"></param> lien pour accedé a l'image
        /// <exception cref="ArgumentNullException"></exception>
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

        /// <summary>
        /// Constructeur du joueur avec toutes les données possible.
        /// </summary>
        /// <param name="pseudo"></param> identifiant du joueur, le pseudo est unique
        /// <param name="age"></param> age du joueur
        /// <param name="nom"></param> nom du joueur
        /// <param name="prenom"></param> prenom du joueur 
        /// <param name="nomImage"></param> lien pour accedé a l'image
        /// <exception cref="ArgumentNullException"></exception>
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

        /// <summary>
        /// Constructeur du joueur sans l'avatar qui n'est pas obligatoire.
        /// </summary>
        /// <param name="pseudo"></param> identifiant du joueur, le pseudo est unique
        /// <param name="age"></param> age du joueur
        /// <param name="nom"></param> nom du joueur
        /// <param name="prenom"></param> prenom du joueur 
        /// <exception cref="ArgumentNullException"></exception>
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

        /// <summary>
        /// Constructeur du joueur avec seulement les paramètres neccesaires, pseudo et age.
        /// </summary>
        /// <param name="pseudo"></param> identifiant du joueur, le pseudo est unique
        /// <param name="age"></param> age du joueur
        /// <exception cref="ArgumentNullException"></exception>
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

        /// <summary>
        /// Constructeur du joueur avec seulement les paramètres neccesaires, pseudo et age.
        /// </summary>
        /// <param name="id"></param> Identifiant du joueur
        /// <param name="pseudo"></param> identifiant du joueur, le pseudo est unique
        /// <param name="age"></param> age du joueur
        /// <exception cref="ArgumentNullException"></exception>
        public Joueur(int id, string pseudo, int age)
        {
            if (String.IsNullOrEmpty(pseudo))
            {
                throw new ArgumentNullException(nameof(pseudo));
            }
            Id = id;
            Pseudo = pseudo;
            Nom = "";
            Prenom = "";
            Age = age;
            URLIMG = "../image/imageParDefaut.jpeg";
        }

        /// <summary>
        /// Constructeur du joueur avec seulement les paramètres neccesaires et un avatar.
        /// </summary>
        /// <param name="pseudo"></param> identifiant du joueur, le pseudo est unique
        /// <param name="age"></param> age du joueur
        /// <param name="nomImage"></param> lien pour accedé a l'image
        /// <exception cref="ArgumentNullException"></exception>
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
            return autreJoueur.Pseudo.Equals(pseudo);
        }

        public override bool Equals(object? obj)
        {
            if(ReferenceEquals(null, obj)) { return false; }
            if(ReferenceEquals(this, obj)) { return true; }
            if(obj.GetType() != GetType()) { return false; }
            return Equals(obj as Joueur);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public void ModifierLeJoueur(Joueur nvJoueur)
        {
            pseudo=nvJoueur.Pseudo;
            URLIMG=nvJoueur.URLIMG;
            Age = nvJoueur.Age;
            Nom=nvJoueur.Nom;
            Prenom = nvJoueur.Prenom;
        }
    }
}
