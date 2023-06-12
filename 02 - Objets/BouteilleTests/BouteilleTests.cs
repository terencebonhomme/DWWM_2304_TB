using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bouteille.Tests
{
    [TestClass()]
    public class BouteilleTests
    {
        /**
         * Ouvrir
         */

        /// <summary>
        /// ouvrir une bouteille fermée
        /// </summary>
        [TestMethod()]
        public void OuvrirBouteilleFermee()
        {
            Bouteille eau = new Bouteille("eau", false, 150.0, 150.0);

            Assert.IsTrue(eau.Ouvrir());
            Assert.IsTrue(eau.EstOuverte);
        }

        /// <summary>
        /// fermer une bouteille ouverte
        /// </summary>
        [TestMethod()]
        public void OuvrirBouteilleOuverte()
        {
            Bouteille eau = new Bouteille("eau", true, 100.0, 150.0);

            Assert.IsFalse(eau.Ouvrir());
            Assert.IsTrue(eau.EstOuverte);
        }

        /**
         * Fermer
         */

        /// <summary>
        /// fermer une bouteille fermée
        /// </summary>
        [TestMethod()]
        public void FermerBouteilleFermee()
        {
            Bouteille eau = new Bouteille("eau", false, 100.0, 150.0);

            Assert.IsFalse(eau.Fermer());
            Assert.IsFalse(eau.EstOuverte);
        }

        /// <summary>
        /// fermer une bouteille ouverte
        /// </summary>
        [TestMethod()]
        public void FermerBouteilleOuverte()
        {
            Bouteille eau = new Bouteille("eau", true, 100.0, 150.0);

            Assert.IsTrue(eau.Fermer());
            Assert.IsFalse(eau.EstOuverte);
        }

        /**
         * Vider
         */

        /**
         * Vider > Bouteille entamée
         */

        /// <summary>
        /// vider une partie d'une bouteille fermée
        /// </summary>
        [TestMethod()]
        public void ViderPartiellementBouteilleFermee()
        {
            const double quantiteDeltaEnCl = 10.0;
            double quantiteAvantEnCl;

            Bouteille eau = new Bouteille("eau", false, 100.0, 150.0);

            quantiteAvantEnCl = eau.QuantiteEnCl;

            Assert.IsFalse(eau.Vider(quantiteDeltaEnCl));
            Assert.IsTrue(eau.QuantiteEnCl == quantiteAvantEnCl);
        }
        
        /// <summary>
        /// vider une partie d'une bouteille entamée et ouverte
        /// </summary>
        [TestMethod()]
        public void ViderPartiellementBouteilleEntameeOuverte()
        {
            const double quantiteDeltaEnCl = 10.0;
            double quantiteAvantEnCl;

            Bouteille eau = new Bouteille("eau", true, 100.0, 150.0);

            quantiteAvantEnCl = eau.QuantiteEnCl;

            Assert.IsTrue(eau.Vider(quantiteDeltaEnCl));
            Assert.IsFalse(eau.QuantiteEnCl == quantiteAvantEnCl);
        }

        /// <summary>
        /// vider une partie nulle d'une bouteille entamée et ouverte
        /// </summary>
        [TestMethod()]
        public void ViderPartiellementNullementBouteilleEntameeOuverte()
        {
            const double quantiteDeltaEnCl = 0.0;
            double quantiteAvantEnCl;

            Bouteille eau = new Bouteille("eau", true, 100.0, 150.0);

            quantiteAvantEnCl = eau.QuantiteEnCl;

            Assert.IsFalse(eau.Vider(quantiteDeltaEnCl));
            Assert.IsTrue(eau.QuantiteEnCl == quantiteAvantEnCl);
        }

        /// <summary>
        /// vider une partie excessive la totalité d'une bouteille entamée et ouverte
        /// </summary>
        [TestMethod()]
        public void ViderPartiellementTotaliteBouteilleEntameeOuverte()
        {
            const double quantiteDeltaEnCl = 100.0;
            double quantiteAvantEnCl;

            Bouteille eau = new Bouteille("eau", true, 100.0, 150.0);

            quantiteAvantEnCl = eau.QuantiteEnCl;

            Assert.IsTrue(eau.Vider(quantiteDeltaEnCl));
            Assert.IsFalse(eau.QuantiteEnCl == quantiteAvantEnCl);
        }

        /// <summary>
        /// vider une partie excessive d'une bouteille et ouverte
        /// </summary>
        [TestMethod()]
        public void ViderPartiellementExcessivementBouteilleEntameeOuverte()
        {
            const double quantiteDeltaEnCl = 150.1;
            double quantiteAvantEnCl;

            Bouteille eau = new Bouteille("eau", true, 100.0, 150.0);

            quantiteAvantEnCl = eau.QuantiteEnCl;

            Assert.IsFalse(eau.Vider(quantiteDeltaEnCl));
            Assert.IsTrue(eau.QuantiteEnCl == quantiteAvantEnCl);
        }

        /// <summary>
        /// vider une partie négative d'une bouteille entamée et ouverte
        /// </summary>
        [TestMethod()]
        public void ViderPartiellementNegativementBouteilleEntameeOuverte()
        {
            const double quantiteDeltaEnCl = -10.0;
            double quantiteAvantEnCl;

            Bouteille eau = new Bouteille("eau", true, 100.0, 150.0);

            quantiteAvantEnCl = eau.QuantiteEnCl;

            Assert.IsFalse(eau.Vider(quantiteDeltaEnCl));
            Assert.IsTrue(eau.QuantiteEnCl == quantiteAvantEnCl);
        }

        /// <summary>
        /// vider totalement une bouteille entamée et fermée
        /// </summary>
        [TestMethod()]
        public void ViderTotalementBouteilleEntameeFermee()
        {
            double quantiteAvantEnCl;

            Bouteille eau = new Bouteille("eau", false, 100.0, 150.0);

            quantiteAvantEnCl = eau.QuantiteEnCl;

            Assert.IsFalse(eau.Vider());
            Assert.IsTrue(eau.QuantiteEnCl == quantiteAvantEnCl);
        }

        /// <summary>
        /// vider totalement une bouteille entamée et ouverte
        /// </summary>
        [TestMethod()]
        public void ViderTotalementBouteilleEntameeOuverte()
        {
            double quantiteAvantEnCl;

            Bouteille eau = new Bouteille("eau", true, 100.0, 150.0);

            quantiteAvantEnCl = eau.QuantiteEnCl;

            Assert.IsTrue(eau.Vider());
            Assert.IsFalse(eau.QuantiteEnCl == quantiteAvantEnCl);
            Assert.IsTrue(eau.QuantiteEnCl == 0);
        }

        /**
         * Vider > bouteille pleine
         */

        /// <summary>
        /// vider une partie la totalité d'une bouteille pleine et ouverte
        /// </summary>
        [TestMethod()]
        public void ViderPartiellementTotaliteBouteillePleineOuverte()
        {
            const double quantiteDeltaEnCl = 150.0;
            double quantiteAvantEnCl;

            Bouteille eau = new Bouteille("eau", true, 150.0, 150.0);

            quantiteAvantEnCl = eau.QuantiteEnCl;

            Assert.IsTrue(eau.Vider(quantiteDeltaEnCl));
            Assert.IsFalse(eau.QuantiteEnCl == quantiteAvantEnCl);
        }

        /// <summary>
        /// vider une partie négative d'une bouteille entamée et ouverte
        /// </summary>
        [TestMethod()]
        public void ViderPartiellementNegativementBouteillePleineOuverte()
        {
            const double quantiteDeltaEnCl = -10.0;
            double quantiteAvantEnCl;

            Bouteille eau = new Bouteille("eau", true, 150.0, 150.0);

            quantiteAvantEnCl = eau.QuantiteEnCl;

            Assert.IsFalse(eau.Vider(quantiteDeltaEnCl));
            Assert.IsTrue(eau.QuantiteEnCl == quantiteAvantEnCl);
        }

        /// <summary>
        /// vider totalement une bouteille pleine et ouverte
        /// </summary>
        [TestMethod()]
        public void ViderTotalementBouteillePleineOuverte()
        {
            double quantiteAvantEnCl;

            Bouteille eau = new Bouteille("eau", true, 150.0, 150.0);

            quantiteAvantEnCl = eau.QuantiteEnCl;

            Assert.IsTrue(eau.Vider());
            Assert.IsFalse(eau.QuantiteEnCl == quantiteAvantEnCl);
            Assert.IsTrue(eau.QuantiteEnCl == 0);
        }

        /**
         * Vider > bouteille vide
         */      

        /// <summary>
        /// vider une partie d'une bouteille vide et ouverte
        /// </summary>
        [TestMethod()]
        public void ViderPartiellementBouteilleVideOuverte()
        {
            const double quantiteDeltaEnCl = 10.0;
            double quantiteAvantEnCl;

            Bouteille eau = new Bouteille("eau", true, 0.0, 150.0);

            quantiteAvantEnCl = eau.QuantiteEnCl;

            Assert.IsFalse(eau.Vider(quantiteDeltaEnCl));
            Assert.IsTrue(eau.QuantiteEnCl == quantiteAvantEnCl);
        }

        /// <summary>
        /// vider la totalité d'une bouteille entamée et ouverte
        /// </summary>
        [TestMethod()]
        public void ViderPartiellementTotaliteBouteilleVideOuverte()
        {
            const double quantiteDeltaEnCl = 50.0;
            double quantiteAvantEnCl;

            Bouteille eau = new Bouteille("eau", true, 100.0, 150.0);

            quantiteAvantEnCl = eau.QuantiteEnCl;

            Assert.IsTrue(eau.Vider(quantiteDeltaEnCl));
            Assert.IsFalse(eau.QuantiteEnCl == quantiteAvantEnCl);
        }
        
        /// <summary>
        /// vider une partie négative d'une bouteille vide et ouverte
        /// </summary>
        [TestMethod()]
        public void ViderPartiellementNegativementBouteilleVideOuverte()
        {
            const double quantiteDeltaEnCl = -10.0;
            double quantiteAvantEnCl;

            Bouteille eau = new Bouteille("eau", true, 0.0, 150.0);

            quantiteAvantEnCl = eau.QuantiteEnCl;

            Assert.IsFalse(eau.Vider(quantiteDeltaEnCl));
            Assert.IsTrue(eau.QuantiteEnCl == quantiteAvantEnCl);
        }

        /// <summary>
        /// vider totalement une bouteille vide et ouverte
        /// </summary>
        [TestMethod()]
        public void ViderTotalementBouteilleVideOuverte()
        {
            double quantiteAvantEnCl;

            Bouteille eau = new Bouteille("eau", true, 0.0, 150.0);

            quantiteAvantEnCl = eau.QuantiteEnCl;

            Assert.IsFalse(eau.Vider());
            Assert.IsTrue(eau.QuantiteEnCl == quantiteAvantEnCl);
            Assert.IsTrue(eau.QuantiteEnCl == 0);
        }

        /**
         * Remplir
         */

        /**
         * Remplir > bouteille entamée
         */

        /// <summary>
        /// remplir partiellement une bouteille entamée et fermee
        /// </summary>
        [TestMethod()]
        public void RemplirPartiellementBouteilleEntameeFermee()
        {
            const double quantiteDeltaEnCl = 10.0;
            double quantiteAvantEnCl;

            Bouteille eau = new Bouteille("eau", false, 100.0, 150.0);

            quantiteAvantEnCl = eau.QuantiteEnCl;

            Assert.IsFalse(eau.Remplir(quantiteDeltaEnCl));
            Assert.IsTrue(eau.QuantiteEnCl == quantiteAvantEnCl);
        }
        
        /// <summary>
        /// remplir partiellement une bouteille entamée et ouverte
        /// </summary>
        [TestMethod()]
        public void RemplirPartiellementBouteilleEntameeOuverte()
        {
            const double quantiteDeltaEnCl = 10.0;
            double quantiteAvantEnCl;

            Bouteille eau = new Bouteille("eau", true, 100.0, 150.0);

            quantiteAvantEnCl = eau.QuantiteEnCl;

            Assert.IsTrue(eau.Remplir(quantiteDeltaEnCl));
            Assert.IsFalse(eau.QuantiteEnCl == quantiteAvantEnCl);
        }

        /// <summary>
        /// remplir partiellement avec une valeur négative une bouteille entamée et ouverte
        /// </summary>
        [TestMethod()]
        public void RemplirPartiellementNegativementBouteilleEntameeOuverte()
        {
            const double quantiteDeltaEnCl = -10.0;
            double quantiteAvantEnCl;

            Bouteille eau = new Bouteille("eau", true, 100.0, 150.0);

            quantiteAvantEnCl = eau.QuantiteEnCl;

            Assert.IsFalse(eau.Remplir(quantiteDeltaEnCl));
            Assert.IsTrue(eau.QuantiteEnCl == quantiteAvantEnCl);
        }

        /// <summary>
        /// remplir partiellement avec une valeur excessive une bouteille entamée et ouverte
        /// </summary>
        [TestMethod()]
        public void RemplirPartiellementExcessivementBouteilleEntameeOuverte()
        {
            const double quantiteDeltaEnCl = 50.1;
            double quantiteAvantEnCl;

            Bouteille eau = new Bouteille("eau", true, 100.0, 150.0);

            quantiteAvantEnCl = eau.QuantiteEnCl;

            Assert.IsFalse(eau.Remplir(quantiteDeltaEnCl));
            Assert.IsTrue(eau.QuantiteEnCl == quantiteAvantEnCl);
        }

        /// <summary>
        /// remplir partiellement jusqu'à la totalité une bouteille entamée et ouverte
        /// </summary>
        [TestMethod()]
        public void RemplirPartiellementTotaliteBouteilleEntameeOuverte()
        {
            const double quantiteDeltaEnCl = 50.0;
            double quantiteAvantEnCl;

            Bouteille eau = new Bouteille("eau", true, 100.0, 150.0);

            quantiteAvantEnCl = eau.QuantiteEnCl;

            Assert.IsTrue(eau.Remplir(quantiteDeltaEnCl));
            Assert.IsFalse(eau.QuantiteEnCl == quantiteAvantEnCl);
        }

        /**
         * Vider > bouteille pleine
         */

        /// <summary>
        /// remplir partiellement une bouteille pleine et ouverte
        /// </summary>
        [TestMethod()]
        public void RemplirPartiellementBouteilleOuvertePleine()
        {
            const double quantiteDeltaEnCl = 10.0;
            double quantiteAvantEnCl;

            Bouteille eau = new Bouteille("eau", true, 150.0, 150.0);

            quantiteAvantEnCl = eau.QuantiteEnCl;

            Assert.IsFalse(eau.Remplir(quantiteDeltaEnCl));
            Assert.IsTrue(eau.QuantiteEnCl == quantiteAvantEnCl);
        }

        /// <summary>
        /// remplir partiellement avec une valeur négative une bouteille pleine et ouverte
        /// </summary>
        [TestMethod()]
        public void RemplirPartiellementNegativementBouteillePleineOuverte()
        {
            const double quantiteDeltaEnCl = -10.0;
            double quantiteAvantEnCl;

            Bouteille eau = new Bouteille("eau", true, 150.0, 150.0);

            quantiteAvantEnCl = eau.QuantiteEnCl;

            Assert.IsFalse(eau.Remplir(quantiteDeltaEnCl));
            Assert.IsTrue(eau.QuantiteEnCl == quantiteAvantEnCl);
        }

        /**
         * Vider > bouteille vide
         */

        /// <summary>
        /// remplir partiellement une bouteille vide et ouverte
        /// </summary>
        [TestMethod()]
        public void RemplirPartiellementBouteilleVideOuverte()
        {
            const double quantiteDeltaEnCl = 10.0;
            double quantiteAvantEnCl;

            Bouteille eau = new Bouteille("eau", true, 0.0, 150.0);

            quantiteAvantEnCl = eau.QuantiteEnCl;

            Assert.IsTrue(eau.Remplir(quantiteDeltaEnCl));
            Assert.IsFalse(eau.QuantiteEnCl == quantiteAvantEnCl);
        }

        /// <summary>
        /// remplir partiellement avec une valeur négative une bouteille vide et ouverte
        /// </summary>
        [TestMethod()]
        public void RemplirPartiellementNegativementBouteilleVideOuverte()
        {
            const double quantiteDeltaEnCl = -10.0;
            double quantiteAvantEnCl;

            Bouteille eau = new Bouteille("eau", true, 0.0, 150.0);

            quantiteAvantEnCl = eau.QuantiteEnCl;

            Assert.IsFalse(eau.Remplir(quantiteDeltaEnCl));
            Assert.IsTrue(eau.QuantiteEnCl == quantiteAvantEnCl);
        }

        /// <summary>
        /// remplir totalement une bouteille vide et ouverte
        /// </summary>
        [TestMethod()]
        public void RemplirTotalementBouteilleVideOuverte()
        {
            double quantiteAvantEnCl;

            Bouteille eau = new Bouteille("eau", true, 0.0, 150.0);

            quantiteAvantEnCl = eau.QuantiteEnCl;

            Assert.IsTrue(eau.Remplir());
            Assert.IsFalse(eau.QuantiteEnCl == quantiteAvantEnCl);
            Assert.IsTrue(eau.QuantiteEnCl == eau.CapaciteEnCl);
        }
    }
}