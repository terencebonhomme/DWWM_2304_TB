using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction.Tests
{
    [TestClass()]
    public class FractionTests
    {
        [TestMethod()]
        public void FractionTest()
        {
            Fraction fraction = new Fraction(2, 0);

            Assert.IsFalse(fraction.Denominateur == 0);
        }

        [TestMethod()]
        public void OpposseTest()
        {
            int numerateurAvant;

            Fraction fraction = new Fraction(2, 3);

            numerateurAvant = 2;
            fraction.Oppose();

            Assert.IsTrue(fraction.Numerateur == -numerateurAvant);
        }

        [TestMethod()]
        public void InverseTest()
        {
            int numerateurAvant;
            int denominateurAvant;

            Fraction fraction = new Fraction(2, 3);

            numerateurAvant = fraction.Numerateur;
            denominateurAvant = fraction.Denominateur;
            fraction.Inverse();

            Assert.IsTrue(fraction.Numerateur == denominateurAvant);
            Assert.IsTrue(fraction.Denominateur == numerateurAvant);
        }

        [TestMethod()]
        public void SuperieurATest()
        {
            Fraction f1 = new Fraction(11, 7);
            Fraction f2 = new Fraction(5, 4);

            bool estSuperieur = f1.SuperieurA(f2);

            Assert.IsTrue(estSuperieur);
        }

        [TestMethod()]
        public void EgalATest()
        {
            Fraction f1 = new Fraction(11, 7);
            Fraction f2 = new Fraction(22, 14);

            bool estEgal = f1.EgalA(f2);

            Assert.IsTrue(estEgal);
        }

        [TestMethod()]
        public void ToDisplayTest()
        {
            Fraction f = new Fraction(120, -150);

            Assert.IsTrue(f.ToDisplay() == "-4/5");
        }

        [TestMethod()]
        public void GetValueTest()
        {
            Fraction f1 = new Fraction(11, 7);

            Assert.IsTrue(f1.GetValue() == f1.Numerateur / f1.Denominateur);
        }

        [TestMethod()]
        public void PlusTest()
        {
            Fraction f1 = new Fraction(11, 7);
            Fraction f2 = new Fraction(5, 4);

            Assert.IsTrue(f1.Plus(f2) == new Fraction(79, 28));
        }

        [TestMethod()]
        public void MoinsTest()
        {
            Fraction f1 = new Fraction(11, 7);
            Fraction f2 = new Fraction(5, 4);

            Assert.IsTrue(f1.Moins(f2) == new Fraction(9, 28));
        }

        [TestMethod()]
        public void MultiplieTest()
        {
            Fraction f1 = new Fraction(11, 7);
            Fraction f2 = new Fraction(5, 4);

            Assert.IsTrue(f1.Multiplie(f2) == new Fraction(55, 28));
        }

        [TestMethod()]
        public void DiviseTest()
        {
            Fraction f1 = new Fraction(11, 7);
            Fraction f2 = new Fraction(5, 4);

            Assert.IsTrue(f1.Divise(f2) == new Fraction(44, 35));
        }
    }
}