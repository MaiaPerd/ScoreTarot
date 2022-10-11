using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Entity
{
    [Table("Partie")]
    public class PartieEntity
    {
        [Key]
        public int Id { get;  set; }

        [Required]
        public IEnumerable<JoueurEntity> Joueurs
        {
            get
            {
                return PartieJoueurs.Select(partieJoueur => partieJoueur.Joueur);
            }
        }

        public void AjouterJoueur(JoueurEntity joueur)
        {
            PartieJoueurs.Add(new PartieJoueur() { Partie = this, Joueur = joueur });
        }

        public virtual ICollection<PartieJoueur> PartieJoueurs { get; set; } = new List<PartieJoueur>();


        [ForeignKey("PartieForeignKey")]
        public List<MancheEntity> Manches { get;  set; }
     

    }
}
