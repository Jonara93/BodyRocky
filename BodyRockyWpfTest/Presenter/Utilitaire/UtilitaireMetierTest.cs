using BodyRockyWPF.Presenter.Utilitaire;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BodyRockyWpfTest.Presenter.Utilitaire
{
    [TestClass]
    class UtilitaireMetierTest
    {
        [TestMethod]
        public void TestTransformeString()
        {
            string intitule = "kArATE";

            string actual = UtilitaireMetier.TransformeString(intitule);

            string expected = "Karate";

            Assert.Equals(true, false);
        }
    }
}
