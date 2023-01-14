using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class PartieDto
    {
        public int Id { get; set; }
        public  List<JoueurDto> Joueurs { get; set; }
        public List<MancheDto> Manches { get; set; }
        
    }
}
