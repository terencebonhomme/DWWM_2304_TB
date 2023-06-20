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
    public class VoitureTests
    {
        [TestMethod()]
        public void DemarrerTest()
        {
            Voiture voiture = new Voiture();

            Assert.IsFalse(voiture.SonMoteur.EnMarche);
            Assert.IsTrue(voiture.Demarrer());
            Assert.IsTrue(voiture.SonMoteur.EnMarche);
        }

        [TestMethod()]
        public void CouperContactTest()
        {
            Voiture voiture = new Voiture();

            Assert.IsFalse(voiture.SonMoteur.EnMarche);
            Assert.IsFalse(voiture.CouperContact());
            Assert.IsTrue(voiture.Demarrer());
            Assert.IsTrue(voiture.CouperContact());
            Assert.IsFalse(voiture.SonMoteur.EnMarche);
        }

        [TestMethod()]
        public void AvancerTest()
        {
            Voiture voiture = new Voiture();

            Assert.IsFalse(voiture.Avancer());
            Assert.IsFalse(voiture.Ses4Roues.ElementAt(0).Tourne);
            Assert.IsFalse(voiture.Ses4Roues.ElementAt(1).Tourne);
            Assert.IsTrue(voiture.Demarrer());
            Assert.IsTrue(voiture.Avancer());
            Assert.IsTrue(voiture.Ses4Roues.ElementAt(0).Tourne);
            Assert.IsTrue(voiture.Ses4Roues.ElementAt(1).Tourne);
        }

        [TestMethod()]
        public void FreinerTest()
        {
            Voiture voiture = new Voiture();

            Assert.IsFalse(voiture.Freiner());
            Assert.IsTrue(voiture.Demarrer());
            Assert.IsFalse(voiture.Freiner());
            Assert.IsTrue(voiture.Avancer());
            Assert.IsTrue(voiture.Freiner());
            Assert.IsTrue(voiture.SonMoteur.EnMarche);
            Assert.IsFalse(voiture.Ses4Roues.ElementAt(0).Tourne);
            Assert.IsFalse(voiture.Ses4Roues.ElementAt(1).Tourne);
        }
    }
}