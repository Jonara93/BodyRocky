using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BodyRockyWPF.Model.model;

namespace BodyRockyWPF.Model.metier
{
    public class Produit
    {
        public Int32 IdProduit { get; set; }
        public String Intitule { get; set; }
        public String Description { get; set; }
        public byte[] Photo { get; set; }
        public Decimal Prix { get; set; }
        public bool Actif { get; set; }
        public Int32 Quantite { get; set; }
        public TypeProduit TypeProduit { get; set; }

        public Produit() { }

        public Produit(String intitule)
        {
            this.Intitule = intitule;
        }
        public Produit(String intitule, String description, byte[] photo, Decimal prix, bool actif, TypeProduit TypeProduit, int quantite) : this(intitule)
        {
            this.Description = description;
            this.Photo = photo;
            this.Prix = prix;
            this.Actif = actif;
            this.TypeProduit = TypeProduit;
            this.Quantite = quantite;
        }
        public Produit(Int32 IdProduit, String intitule, String description, byte[] photo, Decimal prix, bool actif, TypeProduit TypeProduit, int quantite)
            : this(intitule, description, photo, prix, actif, TypeProduit, quantite)
        {
            this.IdProduit = IdProduit;
        }
        public Produit(Produit produit)
        {
            this.Intitule = produit.Intitule;
            this.Description = produit.Description;
            this.Photo = produit.Photo;
            this.Prix = produit.Prix;
            this.Actif = produit.Actif;
            this.Quantite = produit.Quantite;
            this.TypeProduit = new TypeProduit(produit.TypeProduit);
        }

        public override bool Equals(object obj)
        {
            return obj is Produit produit &&
                   IdProduit == produit.IdProduit &&
                   Intitule == produit.Intitule;
        }

        public override int GetHashCode()
        {
            int hashCode = 134881418;
            hashCode = hashCode * -1521134295 + IdProduit.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Intitule);
            return hashCode;
        }

        public override string ToString()
        {
            return Intitule + " : " + Prix + "€";
        }
    }
}
