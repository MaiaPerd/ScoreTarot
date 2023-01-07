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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get;  set; }

        public ICollection<MancheEntity> Manches { get; set; } = new List<MancheEntity>();
        public ICollection<JoueurEntity> Joueurs { get; set; } = new List<JoueurEntity>();

        /*public void AjouterJoueur(JoueurEntity joueur)
        {
            this.Joueurs.Add(joueur);
            PartieJoueurs.Add(new PartieJoueur() { Partie = this, Joueur = joueur, PartieForeignKey = this.Id, JoueurForeignKey = joueur.Pseudo });
        }

        public virtual ICollection<PartieJoueur> PartieJoueurs { get; set; } = new List<PartieJoueur>();
        */

        /*
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
        */
       
     

    }
}
