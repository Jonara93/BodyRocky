using System;
using System.Collections.Generic;
using System.Text;
using BodyRockyWPF.Model.metier;
using BodyRockyWPF.Model.model;
using BodyRockyWPF.Presenter;
using NUnit.Framework;

namespace BodyRockyWpfTestNUnit.Presenter
{
    public class ProduitDetailPresenterTest
    {
        private ProduitDetailPresenter pdp;

        [SetUp]
        public void Setup()
        {
            pdp = new ProduitDetailPresenter();
        }

        [Test]
        public void TestInjectionDonneeProduit_ProduitNull()
        {
            Produit produit = buildProduit("Vélo", 10, "Cyclisme");

            Produit produitAInjecter = null;

            pdp.Produit = produit;

            pdp.InjectionDonneeProduit(produitAInjecter);

            Assert.AreEqual(null, pdp.Produit.Intitule);
            Assert.AreEqual(null, pdp.Produit.TypeProduit.Intitule);
            Assert.AreEqual(0, pdp.Produit.Prix);
        }

        [Test]
        public void TestInjectionDonneeProduit_ProduitNotNull()
        {
            Produit produit = buildProduit("Vélo", 10, "Cyclisme");

            Produit produitAInjecter = buildProduit("Kimono", 20, "Karaté");

            pdp.Produit = produit;

            pdp.InjectionDonneeProduit(produitAInjecter);

            Assert.AreEqual("Kimono", pdp.Produit.Intitule);
            Assert.AreEqual(20, pdp.Produit.Prix);
            Assert.AreEqual("Karaté", pdp.Produit.TypeProduit.Intitule);
        }

        private Produit buildProduit(string intitule, decimal prix, string intituleTP)
        {
            Produit produit = new Produit();
            produit.Prix = prix;
            produit.Intitule = intitule;
            produit.TypeProduit = buildTypeProduit(intituleTP);
            return produit;
        }

        private TypeProduit buildTypeProduit(string intitule)
        {
            TypeProduit tp = new TypeProduit();
            tp.Intitule = intitule;
            return tp;
        }
    }
}
