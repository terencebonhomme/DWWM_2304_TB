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
    public class RoueTests
    {
        [TestMethod()]
        public void RoueTest()
        {
            Roue r1 = new Roue();
            Roue r2 = new Roue(r1);

            Assert.IsFalse(r1.GetHashCode() == r2.GetHashCode());
            Assert.AreNotEqual(r1, r2);
        }
    }
}