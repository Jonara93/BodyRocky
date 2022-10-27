using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyRockyWPF.Model.metier
{
    public class Commande
    {
        public int IdCommande { get; set; }
        public Adresse AdresseLivraison { get; set; }
        public Adresse AdresseFacturation { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public Statut_Cmd Statut { get; set; }
        public Dictionary<Produit, int> Produits { get; set; }

        public Commande() { }

       public Commande(int idCommande, Adresse adrLiv, Adresse adrFac, Statut_Cmd statut, Utilisateur utilisateur)
        {
            IdCommande = idCommande;
            AdresseLivraison = adrLiv;
            AdresseFacturation = adrFac;
            Utilisateur = utilisateur;
            Statut = statut;
        }

       public Commande(int idCommande, Adresse adrLiv, Adresse adrFac, Statut_Cmd statut, Utilisateur utilisateur, Dictionary<Produit, int> produits) :
            this(idCommande, adrLiv, adrFac, statut, utilisateur)
        {
            Produits = produits;
        }

        public Decimal PrixTotal
        {
            get
            {
                Decimal prixTotal = 0;
                foreach (var item in Produits)
                {
                    prixTotal += item.Key.Prix * item.Value;
                }

                return prixTotal;
            }
        }
    }
}
