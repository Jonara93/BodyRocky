using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyRockyWPF.Model.metier
{
    public class Statut_Cmd
    {
        public int IdStatutCmd { get; set; }
        public String Intitule { get; set; }

        public Statut_Cmd() { }
        public Statut_Cmd(String intitule)
        {
            this.Intitule = intitule;
        }
        public Statut_Cmd(int idStatutCmd, String intitule) : this(intitule)
        {
            this.IdStatutCmd = idStatutCmd;
        }

        public Statut_Cmd(Statut_Cmd tp)
        {
            this.IdStatutCmd = tp.IdStatutCmd;
            this.Intitule = tp.Intitule;
        }

        public override bool Equals(object obj)
        {
            return obj is Statut_Cmd statutCmd &&
                   IdStatutCmd == statutCmd.IdStatutCmd;
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
