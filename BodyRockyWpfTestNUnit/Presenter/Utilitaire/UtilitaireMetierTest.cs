using System;
using System.Collections.Generic;
using System.Text;
using BodyRockyWPF.Presenter.ExceptionUtil;
using BodyRockyWPF.Presenter.Utilitaire;
using NUnit.Framework;

namespace BodyRockyWpfTestNUnit.Presenter.Utilitaire
{
    class UtilitaireMetierTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestTransformString_OK_StringGT1()
        {
            string intitule = "kaRAte";

            string actual = UtilitaireMetier.TransformeString(intitule);
            string expected = "Karate";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestTransformString_OK_StringE1()
        {
            string intitule = "k";

            string actual = UtilitaireMetier.TransformeString(intitule);
            string expected = "K";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestTransformString_NOK_Null()
        {
            string intitule = null;

            Assert.Throws<ExceptionMetier>(() => UtilitaireMetier.TransformeString(intitule));
        }

        [Test]
        public void TestTransformString_NOK_Empty()
        {
            string intitule = "";

            Assert.Throws<ExceptionMetier>(() => UtilitaireMetier.TransformeString(intitule));
        }

        [Test]
        public void TestTransformString_NOK_Blank()
        {
            string intitule = "   ";

            Assert.Throws<ExceptionMetier>(() => UtilitaireMetier.TransformeString(intitule));
        }
    }
}
