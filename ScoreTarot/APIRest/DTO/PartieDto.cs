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
        public  List<int> JoueursId { get; set; }
        public List<int> ManchesId { get; set; }
        public int Id { get; set; }
    }
}
