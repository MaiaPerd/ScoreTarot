using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Entity
{
    [Table("Manche")]
    public class MancheEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Score { get; set; }
        [Required]
        public int NbJoueur { get; set; }
        [Required]
        public ContratEntity Contrat { get; set; }
        public BonusEntity Bonus { get; set; }
        [Required]
        [MaxLength(20)]
        public JoueurEntity JoueurQuiPrend { get; set; }
        [MaxLength(20)]
        public JoueurEntity JoueurAllier { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("PartieForeignKey")]
        public PartieEntity Partie { get; set; }
       
    }
}
