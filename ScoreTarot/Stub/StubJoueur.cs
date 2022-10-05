using Model;

namespace Stub
{
    public class StubJoueur
    {
        internal List<Joueur> ChargerJoueur()
        {
            List<Joueur> joueurs = new List<Joueur>();
            joueurs.Add(new Joueur("albertus", 56, "Patricus"));
            joueurs.Add(new Joueur("dani", 10, "Duboit", "daniel", "dani_avatar.png"));
            joueurs.Add(new Joueur("dani1", 10, "Duboit", "", "dani_avatar.png"));
            joueurs.Add(new Joueur("dani2", 10, "Duboit", "daniel", ""));
            joueurs.Add(new Joueur("dani3", 10, "Duboit", "daniel", "dani_avatar"));
            joueurs.Add(new Joueur("dani4", 0 , "Duboit", "daniel", "dani_avatar.png"));
            joueurs.Add(new Joueur("Nathan", 10, "Duboit", "daniel", "dani_avatar.png"));
            joueurs.Add(new Joueur("Andreas", 10, "Duboit", "andré", "dani_avatar.png"));
            joueurs.Add(new Joueur("dani5", 10, null, "daniel", "dani_avatar.png"));
            joueurs.Add(new Joueur("dani6", 10, "Duboit", null, "dani_avatar.png"));
            joueurs.Add(new Joueur("dani7", 10, "Duboit", "daniel", null));
            joueurs.Add(new Joueur("dani8", 10, "qerg468qe6g46qerh", "daniel", "dani_avatar.png"));
            joueurs.Add(new Joueur("dani", 10, "Duboit", "daniel", "dani_avatar.png"));
            joueurs.Add(new Joueur("dani11", 10, "Duboit", "daniel", "dani_avatar.png"));
            joueurs.Add(new Joueur("Louloul", 10, "Duboit", "Laurant", "dani_avatar.png"));
            joueurs.Add(new Joueur("dani45", 10, "     ", "daniel", "dani_avatar.png"));
            joueurs.Add(new Joueur("darni7897", 10, "Duboit", "     ", "dani_avatar.png"));
            joueurs.Add(new Joueur("dani4654", 11, "Duboit", "daniel", "      "));
            joueurs.Add(new Joueur("dani84", 16, "Duboit", "daniel", "      .png"));
            joueurs.Add(new Joueur("Andreal", 58, "Bourdin", "Andrea", "andread.png"));
            joueurs.Add(new Joueur("Pat", 29, "Bourbier", "Patrick", "patpat_avatar.png"));
            joueurs.Add(new Joueur("Albertus", 50, "DE-LA-CROIX", "", "dani_avatar.png"));
            joueurs.Add(new Joueur("francus", 46, "dupuit", "franc", "dani_avatar.png"));
            joueurs.Add(new Joueur("Franchaisca", 44, null, "Marie", "marie_avatar.png"));
            joueurs.Add(new Joueur("chaise", 10, "Duboit", "laTable", "tabouret.png"));
            joueurs.Add(new Joueur("BlobFish", 10001, "DeLeau", "poisson", "elPouascaille.png"));
            return joueurs;
        }

        internal List<Joueur> ChargerJoueurPartie3J()
        {
            List<Joueur> joueurs = new List<Joueur>();
            joueurs.Add(new Joueur("albertus", 56, "Patricus"));
            joueurs.Add(new Joueur("dani", 10, "Duboit", "daniel", "dani_avatar.png"));
            joueurs.Add(new Joueur("egard", 10, "Duboit", "", "dani_avatar.png"));
            return joueurs;
        }

        internal List<Joueur> ChargerJoueurPartie4J()
        {
            List<Joueur> joueurs = new List<Joueur>();
            joueurs.Add(new Joueur("albertus", 56, "Patricus"));
            joueurs.Add(new Joueur("dani", 10, "Duboit", "daniel", "dani_avatar.png"));
            joueurs.Add(new Joueur("egard", 10, "Duboit", "", "dani_avatar.png"));
            joueurs.Add(new Joueur("chaise", 10, "Duboit", "laTable", "tabouret.png"));
            return joueurs;
        }

        internal List<Joueur> ChargerJoueurPartie5J()
        {
            List<Joueur> joueurs = new List<Joueur>();
            joueurs.Add(new Joueur("albertus", 56, "Patricus"));
            joueurs.Add(new Joueur("dani", 10, "Duboit", "daniel", "dani_avatar.png"));
            joueurs.Add(new Joueur("egard", 10, "Duboit", "", "dani_avatar.png"));
            joueurs.Add(new Joueur("chaise", 10, "Duboit", "laTable", "tabouret.png"));
            joueurs.Add(new Joueur("Andreal", 58, "Bourdin", "Andrea", "andread.png"));
            return joueurs;
        }
    }
}

