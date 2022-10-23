using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Entity
{
    public class PartieJoueur
    {
        
            public PartieEntity Partie { get; set; }

            public JoueurEntity Joueur { get; set; }
        /*
        [Key]
        public int id { get; set; }
        */
        [ForeignKey("PartieForeignKey")]
        public int PartieForeignKey { get; set; }


        [ForeignKey("JoueurForeignKey")]
        public string JoueurForeignKey { get; set; }
        /*
        [Key]
        public int id { get; set; }

        [ForeignKey("PartieForeignKey")]
        public int Partie { get; set; }

        [ForeignKey("JoueurForeignKey")]
        public int Joueur { get; set; }*/
    }
}

