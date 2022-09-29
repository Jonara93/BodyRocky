using System;
using System.Collections.Generic;
using System.Text;
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

            Assert.False(ValidateurUtil.IsTypeCategorieValidEtPasExistant(tp,listTp));
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
    }
}
