using Microsoft.VisualStudio.TestTools.UnitTesting;
using Voiture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voiture.Tests
{
    [TestClass()]
    public class MoteurTests
    {
        [TestMethod()]
        public void MoteurTest()
        {
            Moteur m1 = new Moteur();
            Moteur m2 = new Moteur(m1);

            Assert.IsFalse(m1.GetHashCode() == m2.GetHashCode());
            Assert.AreNotEqual(m1, m2);
        }
    }
}