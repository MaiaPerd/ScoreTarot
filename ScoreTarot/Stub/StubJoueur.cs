using Model;

namespace Stub;
public class StubJoueur
{
    public List<Joueur> chargerJoueur()
    {
        List<Joueur> joueurs = new List<Joueur>();
        joueurs.Add(new Joueur("albertus", 56, "Patricus"));
        joueurs.Add(new Joueur("dani",10,"Duboit","daniel","dani_avatar.png"));
        return joueurs;
    }
}

