using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Entity
{
    [Table("Joueur")]
    public class JoueurEntity
    {
        [Key]
        public string Pseudo { get; set; }
        public string Nom { get;  set; }
        public string Prenom { get;  set; }
        [Required]
        public int Age { get;  set; }
        public string URLIMG { get;  set; }

        public IEnumerable<PartieEntity> Parties
        {
            get
            {
                return PartieJoueurs.Select(partieJoueur => partieJoueur.Partie);
            }
        }

        public void AjouterPartie(PartieEntity partie)
        {
            PartieJoueurs.Add(new PartieJoueur() { Partie = partie, Joueur = this }) ;
        }

        public virtual ICollection<PartieJoueur> PartieJoueurs { get; set; } = new List<PartieJoueur>();


    }
}
