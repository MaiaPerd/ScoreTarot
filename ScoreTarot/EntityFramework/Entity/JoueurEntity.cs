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
        [MaxLength(20)]
        public string Pseudo { get; set; }
        [MaxLength(15)]
        public string Nom { get;  set; }
        [MaxLength(20)]
        public string Prenom { get;  set; }
        public string URLIMG { get; set; }
        [Required]
        public int Age { get;  set; }
        
        public ICollection<PartieEntity> Parties { get; set; } = new List<PartieEntity>();
        
        /*
        public IEnumerable<PartieEntity> Parties
        {
            get
            {
                return PartieJoueurs.Select(partieJoueur => partieJoueur.Partie);
            }
        }*/

        public void AjouterPartie(PartieEntity partie)
        {
            this.Parties.Add(partie);
            PartieJoueurs.Add(new PartieJoueur() { Partie = partie, Joueur = this, JoueurForeignKey = this.Pseudo, PartieForeignKey = partie.Id }) ;
        }

        public virtual ICollection<PartieJoueur> PartieJoueurs { get; set; } = new List<PartieJoueur>();
        

    }
}
