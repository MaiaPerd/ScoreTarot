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
        public int Id { get; set; }
        [Required]
        public int Score { get; set; }
        [Required]
        public int NbJoueur { get; set; }
        [Required]
        public ContratEntity Contrat { get;  set; }
        public List<BonusEntity> Bonus { get;  set; }
        [Required]
        public JoueurEntity JoueurQuiPrend { get; set; }
        public JoueurEntity JoueurAllier { get;  set; }
        public DateTime Date { get;  set; }
        public int PartieForeignKey { get; set; }
       
    }
}
