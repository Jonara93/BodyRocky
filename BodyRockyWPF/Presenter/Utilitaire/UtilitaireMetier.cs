using BodyRockyWPF.Model.metier;
using BodyRockyWPF.Presenter.ExceptionUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyRockyWPF.Presenter.Utilitaire
{
    public static class UtilitaireMetier
    {
        public static String TransformeString(string stringToTransform)
        {
            string toReturn;
            if (string.IsNullOrWhiteSpace(stringToTransform))
            {
                throw new ExceptionMetier("Le texte à transformer ne peut pas être null ou vide");
            }
            else
            {
                stringToTransform = stringToTransform.ToLower();
                toReturn = stringToTransform.Length == 1
                    ? stringToTransform.ToUpper()
                    : string.Concat(stringToTransform[0].ToString().ToUpper(), stringToTransform.Substring(1));
            }
            return toReturn;
        }
    }
}
