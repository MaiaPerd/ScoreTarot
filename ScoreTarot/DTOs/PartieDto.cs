using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class PartieDto
    {
        private IEnumerable<Joueur> enumerable;
        private List<Manche> manches;

        public PartieDto(int id, IEnumerable<Joueur> enumerable, List<Manche> manches)
        {
            Id = id;
            this.enumerable = enumerable;
            this.manches = manches;
        }

        public  List<JoueurDto> Joueurs { get; set; }
        public List<MancheDto> Manches { get; set; }
        public int Id { get; set; }
    }
}
