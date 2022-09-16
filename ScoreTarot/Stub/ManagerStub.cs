
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stub
{
    public class ManagerStub : ILoader
    {
        public Joueur loadJoueur()
        {
            throw new NotImplementedException();
        }

        public Partie loadPartie()
        {
            //return new StubPartie().getDesPartie();
            throw new NotImplementedException();
        }
    }
}
