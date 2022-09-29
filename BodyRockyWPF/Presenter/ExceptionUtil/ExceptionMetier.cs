using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyRockyWPF.Presenter.ExceptionUtil
{
    public class ExceptionMetier : Exception
    {
        public ExceptionMetier(string msgDetail) : base(msgDetail)
        {
        }
    }
}
