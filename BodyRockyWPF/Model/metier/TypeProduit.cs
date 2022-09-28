using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyRockyWPF.Model.model
{
    public class TypeProduit
    {
        public int IdTypeProduit { get; set; }
        public String Intitule { get; set; }

        public TypeProduit() { }
        public TypeProduit(String intitule)
        {
            this.Intitule = intitule;
        }
        public TypeProduit(int idTypeProduit, String intitule) : this(intitule)
        {
            this.IdTypeProduit = idTypeProduit;
        }

        public override bool Equals(object obj)
        {
            return obj is TypeProduit produit &&
                   Intitule == produit.Intitule;
        }

        public override int GetHashCode()
        {
            return -954276747 + EqualityComparer<string>.Default.GetHashCode(Intitule);
        }

        public override string ToString()
        {
            return Intitule;
        }
    }
}
