using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyRockyWPF.Presenter.Utilitaire
{
    class UtilitaireMetier
    {
        public static String TransformeString(string stringToTransform)
        {
            string toReturn;
            if (stringToTransform == null || stringToTransform.Length == 0)
            {
                throw new Exception();
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
