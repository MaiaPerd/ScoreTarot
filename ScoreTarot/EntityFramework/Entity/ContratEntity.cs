using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Entity
{
    public enum ContratEntity
    {
        Prise = 1,
        Garde = 2,
        GardeSans = 4,
        GardeContre = 8
    }
}
