using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Entity
{
    public class JoueurEntity
    {
        public int Id { get;  set; }
        public string Pseudo { get; set; }
        public string Nom { get;  set; }
        public string Prenom { get;  set; }
        public int Age { get;  set; }
        public string URLIMG { get;  set; }

    }
}
