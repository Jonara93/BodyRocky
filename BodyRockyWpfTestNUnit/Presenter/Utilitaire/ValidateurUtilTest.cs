using System;
using System.Collections.Generic;
using System.Text;
using BodyRockyWPF.Model.metier;
using BodyRockyWPF.Model.model;
using BodyRockyWPF.Presenter.Utilitaire;
using NUnit.Framework;

namespace BodyRockyWpfTestNUnit.Presenter.Utilitaire
{
    class ValidateurUtilTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIsTypeCategorieValid_TpNull()
        {
            TypeProduit tp = null;
            List<TypeProduit> listTp = new List<TypeProduit>(new[] { new TypeProduit("Karate"), new TypeProduit("Cyclisme") });

            Assert.False(ValidateurUtil.IsTypeCategorieValidEtPasExistant(tp, listTp));
        }

        [Test]
        public void TestIsTypeCategorieValid_ListTpNull()
        {
            TypeProduit tp = new TypeProduit("Karate");
            List<TypeProduit> listTp = null;

            Assert.False(ValidateurUtil.IsTypeCategorieValidEtPasExistant(tp, listTp));
        }

        [Test]
        public void TestIsTypeCategorieValid_IntituleLongLT4()
        {
            TypeProduit tp = new TypeProduit("Kar");
            List<TypeProduit> listTp = new List<TypeProduit>(new[] { new TypeProduit("Karate"), new TypeProduit("Cyclisme") });


            Assert.False(ValidateurUtil.IsTypeCategorieValidEtPasExistant(tp, listTp));
        }

        [Test]
        public void TestIsTypeCategorieValid_TpInListTp()
        {
            TypeProduit tp = new TypeProduit("Karate");
            List<TypeProduit> listTp = new List<TypeProduit>(new[] { new TypeProduit("Karate"), new TypeProduit("Cyclisme") });


            Assert.False(ValidateurUtil.IsTypeCategorieValidEtPasExistant(tp, listTp));
        }

        [Test]
        public void TestIsTypeCategorieValid_Valid()
        {
            TypeProduit tp = new TypeProduit("Judo");
            List<TypeProduit> listTp = new List<TypeProduit>(new[] { new TypeProduit("Karate"), new TypeProduit("Cyclisme") });


            Assert.True(ValidateurUtil.IsTypeCategorieValidEtPasExistant(tp, listTp));
        }

        [Test]
        public void TestIsTypeCategorieValid_Valid_EmptyList()
        {
            TypeProduit tp = new TypeProduit("Judo");
            List<TypeProduit> listTp = new List<TypeProduit>();


            Assert.True(ValidateurUtil.IsTypeCategorieValidEtPasExistant(tp, listTp));
        }

        [Test]
        public void TestIsListNotNullAndNotEmpty_EmptyList()
        {
            List<TypeProduit> listTp = new List<TypeProduit>();


            Assert.False(ValidateurUtil.IsListNotNullAndNotEmpty(listTp));
        }

        [Test]
        public void TestIsListNotNullAndNotEmpty_FilledList()
        {
            TypeProduit tp = new TypeProduit("Judo");
            List<TypeProduit> listTp = new List<TypeProduit>();
            listTp.Add(tp);


            Assert.True(ValidateurUtil.IsListNotNullAndNotEmpty(listTp));
        }

        [Test]
        public void TestIsListNotNullAndNotEmpty_ListNull()
        {
            List<TypeProduit> listTp = null;


            Assert.False(ValidateurUtil.IsListNotNullAndNotEmpty(listTp));
        }

        [Test]
        public void TestIsListNullOrEmpty_EmptyList()
        {
            List<TypeProduit> listTp = new List<TypeProduit>();


            Assert.True(ValidateurUtil.IsListNullOrEmpty(listTp));
        }

        [Test]
        public void TestIsListNullOrEmpty_FilledList()
        {
            TypeProduit tp = new TypeProduit("Judo");
            List<TypeProduit> listTp = new List<TypeProduit>();
            listTp.Add(tp);

            Assert.False(ValidateurUtil.IsListNullOrEmpty(listTp));
        }

        [Test]
        public void TestIsListNullOrEmpty_ListNull()
        {
            List<TypeProduit> listTp = null;


            Assert.True(ValidateurUtil.IsListNullOrEmpty(listTp));
        }
        
        [Test]
        public void TestIsProduitIntituleUnique_NomUnique()
        {
            List<Produit> listProduits = new List<Produit>(new[] { new Produit("Karate"), new Produit("Cyclisme") });
            Produit produit = new Produit("Woaw");

            Assert.True(ValidateurUtil.IsProduitIntituleUnique(listProduits,produit));
        }

        [Test]
        public void TestIsProduitIntituleUnique_NomPasUnique()
        {
            List<Produit> listProduits = new List<Produit>(new[] { new Produit("Karate"), new Produit("Cyclisme") });
            Produit produit = new Produit("Karate");

            Assert.False(ValidateurUtil.IsProduitIntituleUnique(listProduits, produit));
        }

        [Test]
        public void TestIsProduitValide_ProduitNull()
        {
            Produit produit = null;

            Assert.False(ValidateurUtil.IsProduitValide(produit));
        }

        [Test]
        public void TestIsProduitValide_ProduitIntituleNull()
        {
            Produit produit = new Produit(null,"Une grande description",null,15,true,new TypeProduit("Intitule"),0);

            Assert.False(ValidateurUtil.IsProduitValide(produit));
        }

        [Test]
        public void TestIsProduitValide_ProduitIntituleLT3()
        {
            Produit produit = new Produit("Je", "Une grande description", null, 15, true, new TypeProduit("Intitule"),0);

            Assert.False(ValidateurUtil.IsProduitValide(produit));
        }

        [Test]
        public void TestIsProduitValide_ProduitPrixLT0()
        {
            Produit produit = new Produit("JeuDeMain", "Une grande description", null, -1, true, new TypeProduit("Intitule"),0);

            Assert.False(ValidateurUtil.IsProduitValide(produit));
        }
        [Test]
        public void TestIsProduitValide_ProduitDescriptionNull()
        {
            Produit produit = new Produit("JeuDeMain", null, null, 1, true, new TypeProduit("Intitule"),0);

            Assert.False(ValidateurUtil.IsProduitValide(produit));
        }

        [Test]
        public void TestIsProduitValide_ProduitDescriptionLT10()
        {
            Produit produit = new Produit("JeuDeMain", "Jeu", null, 1, true, new TypeProduit("Intitule"),0);

            Assert.False(ValidateurUtil.IsProduitValide(produit));
        }

        [Test]
        public void TestIsProduitValide_TypeProduitNull()
        {
            Produit produit = new Produit("JeuDeMain", "Jeu avec lequel on utilise ses petites mains", null, 1, true, null,0);

            Assert.False(ValidateurUtil.IsProduitValide(produit));
        }

        [Test]
        public void TestIsProduitValide_QuantiteNegative()
        {
            Produit produit = new Produit("JeuDeMain", "Jeu avec lequel on utilise ses petites mains", null, 1, true, new TypeProduit("Intitule"), -15);

            Assert.False(ValidateurUtil.IsProduitValide(produit));
        }

        [Test]
        public void TestIsProduitValide_ProduitValid()
        {
            Produit produit = new Produit("JeuDeMain", "Jeu avec lequel on utilise ses petites mains", null, 1, true, new TypeProduit("Intitule"),0);

            Assert.True(ValidateurUtil.IsProduitValide(produit));
        }
    }
}
