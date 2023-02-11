using AngleSharp.Common;
using Model;
using Stub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsUnitaires
{
    public class UnitTestStub
    {
        [Fact]
        public void TesterStubJoueur()
        {
            ManagerStub managerStub = new ManagerStub();
            Assert.Equal(26,managerStub.LoadJoueur().Count);
            
        }
        [Fact]
        public void TesterStubLoadPartie()
        {
            ManagerStub managerStub = new ManagerStub();
            Assert.Equal(3, managerStub.LoadPartie().Count);
        }
        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void TesterStubChargerUnePartie(int combienDeJoueur)
        {
            ManagerStub managerStub = new ManagerStub();
            Assert.Equal(combienDeJoueur,managerStub.ChargerUnePartie(combienDeJoueur).Joueurs.Count);
        }
        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void TesterStubChargerDesJoueurPourUnePartie(int combienDeJoueur)
        {
            ManagerStub managerStub = new ManagerStub();
            Assert.Equal(combienDeJoueur, managerStub.ChargerDesJoueurPourUnePartie(combienDeJoueur).Count);
        }
        [Theory]
        [MemberData(nameof(UnitTestControlerDto.Data_TestStub), MemberType = typeof(UnitTestControlerDto))]
        public void TesterStubChargerListManche(int combienDeJoueur,List<Joueur> joueurs,int nbManche)
        {
            ManagerStub managerStub = new ManagerStub();
            Assert.Equal(combienDeJoueur, managerStub.ChargerListManche(combienDeJoueur, joueurs).GetItemByIndex(0).NbJoueur);
            Assert.Equal(nbManche, managerStub.ChargerListManche(combienDeJoueur, joueurs).Count);
        }

    }
}
