using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyRockyWPF.Model.metier
{
    public class Adresse
    {
        public Int32 IdAdresse { get; set; }
        public String Rue { get; set; }
        public String NumeroRue { get; set; }
        public String Cp { get; set; }
        public String Ville { get; set; }

        public Adresse() { }

        public Adresse(int id, string rue, string numeroRue, string cp, string ville) {
            IdAdresse = id;
            Rue = rue;
            NumeroRue = numeroRue;
            Cp = cp;
            Ville = ville;
        }


        public Adresse(Adresse adresse)
        {
            this.IdAdresse = adresse.IdAdresse;
            this.Rue = adresse.Rue;
            this.NumeroRue = adresse.NumeroRue;
            this.Cp = adresse.Cp;
            this.Ville = adresse.Ville;
        }

        public override bool Equals(object obj)
        {
            return obj is Adresse adresse &&
                   IdAdresse == adresse.IdAdresse &&
                   Rue == adresse.Rue &&
                   NumeroRue == adresse.NumeroRue &&
                   Cp == adresse.Cp &&
                   Ville == adresse.Ville;
        }

        public override int GetHashCode()
        {
            int hashCode = 1924969500;
            hashCode = hashCode * -1521134295 + IdAdresse.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Rue);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NumeroRue);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Cp);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Ville);
            return hashCode;
        }

        public override string ToString()
        {
            return Rue + " " + NumeroRue + ", " + Cp + " " + Ville;
        }
    }
}
