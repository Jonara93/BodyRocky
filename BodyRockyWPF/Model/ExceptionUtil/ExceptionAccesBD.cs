using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyRockyWPF.Model.ExceptionUtil
{
    public class ExceptionAccesBD : Exception
    {
        public ExceptionAccesBD(string msgDetail) : base(msgDetail)
        {
        }
    }
}
