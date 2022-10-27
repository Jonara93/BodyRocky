using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyRockyWPF.Model.metier
{
    public class Utilisateur
    {
        public Int32 IdUtilisateur { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public DateTime Ddn { get; set; }
        public String Email { get; set; }
        public String Mdp { get; set; }
        public Boolean Actif { get; set; }
        List<Adresse> Adresses { get; set; }

        public Utilisateur() { }

        public Utilisateur(int idUtilisateur, string nom, string prenom, DateTime ddn, string email, string mdp, bool actif, List<Adresse> adresses) :
            this(nom, prenom, ddn, email, mdp, actif, adresses)
        {
            IdUtilisateur = idUtilisateur;
        }

        public Utilisateur(string nom, string prenom, DateTime ddn, string email, string mdp, bool actif, List<Adresse> adresses)
        {
            Nom = nom;
            Prenom = prenom;
            Ddn = ddn;
            Email = email;
            Mdp = mdp;
            Actif = actif;
            Adresses = adresses;
        }
        public Utilisateur(Utilisateur utilisateur)
        {
            Nom = utilisateur.Nom;
            Prenom = utilisateur.Prenom;
            Ddn = utilisateur.Ddn;
            Email = utilisateur.Email;
            Mdp = utilisateur.Mdp;
            Actif = utilisateur.Actif;

            //copier la liste d'adresse
            List<Adresse> newAdresses = new List<Adresse>();
            utilisateur.Adresses.ForEach(a => newAdresses.Add(new Adresse(a)));
            Adresses = newAdresses;
        }

        public String NomPrenom { get{ return Nom + " " + Prenom; } }

        public override bool Equals(object obj)
        {
            return obj is Utilisateur utilisateur &&
                   IdUtilisateur == utilisateur.IdUtilisateur &&
                   Nom == utilisateur.Nom &&
                   Prenom == utilisateur.Prenom &&
                   Ddn == utilisateur.Ddn;
        }

        public override int GetHashCode()
        {
            int hashCode = -1728551039;
            hashCode = hashCode * -1521134295 + IdUtilisateur.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nom);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Prenom);
            hashCode = hashCode * -1521134295 + Ddn.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return Nom + " " + Prenom + " : " + IdUtilisateur;
        }
    }
}
