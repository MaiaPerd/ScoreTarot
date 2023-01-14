using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public  class MancheDto
    {
        public int Id { get; set; }
        [Required]
        public Contrat Contrat { get; set; }
        public Bonus Bonus { get; set; }
        [Required]
        [StringLength(20)]
        public JoueurDto JoueurQuiPrend { get; set; }
        [StringLength(20)]
        public JoueurDto JoueurAllier { get;  set; }
        [Required]
        public int Score { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get;  set; }
        [Required]
        public int NbJoueur { get;  set; }
        
    }
}
