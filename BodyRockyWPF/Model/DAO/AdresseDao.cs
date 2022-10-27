using BodyRockyWPF.Model.ExceptionUtil;
using BodyRockyWPF.Model.metier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyRockyWPF.Model.DAO
{
    class AdresseDao : BaseDao<Adresse>
    {
        public AdresseDao(SqlConnection sqlConnection) : base(sqlConnection) { }

        public override bool Modifier(Adresse entite)
        {
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandText = "ModifierAdresse";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Connection = SqlConnection;

                sqlCmd.Parameters.Add("@id_adresse", SqlDbType.Int).Value = entite.IdAdresse;
                sqlCmd.Parameters.Add("@rue", SqlDbType.VarChar).Value = entite.Rue;
                sqlCmd.Parameters.Add("@numeroRue", SqlDbType.VarChar).Value = entite.NumeroRue;
                sqlCmd.Parameters.Add("@cp", SqlDbType.VarChar).Value = entite.Cp;
                sqlCmd.Parameters.Add("@ville", SqlDbType.VarChar).Value = entite.Ville;
                sqlCmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                sqlCmd.ExecuteNonQuery();

                return Convert.ToInt32(sqlCmd.Parameters["@RetVal"].Value.ToString()) > 0;
            }
            catch (Exception e)
            {
                throw new ExceptionAccesBD(e.Message);
            }
        }
    }
}
