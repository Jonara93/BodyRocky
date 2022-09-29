using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyRockyWPF.Model.DAO
{
    class FabriqueDao
    {
        private static FabriqueDao instance = new FabriqueDao();

        private SqlConnection SqlConnection = null;

        private FabriqueDao() { }

        public static FabriqueDao GetInstance()
        {
            return instance;
        }

        public void CreerConnexion()
        {
            try
            {
                if (SqlConnection == null)
                {
                    SqlConnection = new SqlConnection("Data Source=localhost;Initial Catalog=rockybody;User ID=SA;Password=1234qwerASDF");
                    SqlConnection.Open();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TypeProduitDao GetTypeProduitDao()
        {
            return new TypeProduitDao(SqlConnection);
        }

    }
}
