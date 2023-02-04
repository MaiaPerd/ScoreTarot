using APIRest.DTOs;
using EntityFramework.Entity;
using Model;

namespace APIRest.MapperClass
{
    public static class Extension
    {
        public static JoueurDto toDTO(this Joueur joueur)
        {
            var jdto = new JoueurDto();
            jdto.Id = joueur.Id;
            jdto.Pseudo = joueur.Pseudo;
            jdto.URLIMG = joueur.URLIMG;
            jdto.Age = joueur.Age;
            jdto.Nom = joueur.Nom;
            jdto.Prenom = joueur.Prenom;

            return jdto;
        }
        public static Joueur toModel(this JoueurDto joueurdto)
        {
            var j = new Joueur(joueurdto.Id, joueurdto.Pseudo, joueurdto.Age, joueurdto.Nom, joueurdto.Prenom, joueurdto.URLIMG);
            return j;
        }
    }
}
