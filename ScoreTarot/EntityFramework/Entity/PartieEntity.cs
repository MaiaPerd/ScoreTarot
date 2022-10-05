using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Entity
{
    public class PartieEntity
    {
        public int Id { get;  set; }
        public List<JoueurEntity> Joueurs { get; set; }
        public List<MancheEntity> Manches { get;  set; }
     

    }
}
