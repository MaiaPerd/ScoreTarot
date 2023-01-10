using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public  class MancheDto
    {
        public Contrat Contrat { get; set; }
        public Bonus Bonus { get; set; }
        public JoueurDto JoueurQuiPrend { get; set; }
        public JoueurDto JoueurAllier { get;  set; }
        public int Score { get; set; }
        public DateTime Date { get;  set; }
        public int Id { get;  set; }
        public int NbJoueur { get;  set; }

    }
}
