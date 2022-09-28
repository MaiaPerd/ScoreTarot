using EntityFramework.Entity;
using Model;

namespace EntityFramework
{
    public static class Extension
    {
        public static JoueurEntity toEntityJoueur(this Joueur joueur)
        {
            JoueurEntity joueurEntity = new JoueurEntity();
            joueurEntity.Id = joueur.Id;
            joueurEntity.Age = joueur.Age;
            joueurEntity.URLIMG = joueur.URLIMG;
            joueurEntity.Pseudo = joueur.Pseudo;
            joueurEntity.Nom = joueur.Nom;
            joueurEntity.Prenom = joueur.Prenom;
            return joueurEntity;
        }



    }
}