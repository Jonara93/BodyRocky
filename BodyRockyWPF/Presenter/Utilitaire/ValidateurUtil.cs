using BodyRockyWPF.Model.metier;
using BodyRockyWPF.Model.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyRockyWPF.Presenter.Utilitaire
{
    public static class ValidateurUtil
    {
        public static bool IsTypeCategorieValidEtPasExistant(TypeProduit tp, List<TypeProduit> listTp)
        {
            return tp != null && listTp != null && tp.Intitule != null && tp.Intitule.Length >= 4 && !listTp.Contains(tp);
        }

        public static bool IsProduitValide(Produit produit)
        {
            return produit != null && produit.Intitule != null && produit.Intitule.Length >= 3
                && produit.Prix >= 0
                && produit.Description != null && produit.Description.Length >= 10
                && produit.TypeProduit != null
                && produit.Quantite >= 0;
        }

        public static bool IsProduitIntituleUnique(List<Produit> listProduit, Produit produit)
        {
            return listProduit.Find(p => p.Intitule.Equals(produit.Intitule)) == null;
        }

        public static bool IsListNotNullAndNotEmpty<T>(List<T> list)
        {
            return list != null && list.Count > 0;
        }

        public static bool IsListNullOrEmpty<T>(List<T> list)
        {
            return list == null || list.Count == 0;
        }
    }
}
