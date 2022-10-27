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
    class StatutCmdDao : BaseDao<Statut_Cmd>
    {
        public StatutCmdDao(SqlConnection sqlConnection) : base(sqlConnection) { }

        public override List<Statut_Cmd> ListerTous()
        {
            List<Statut_Cmd> listStatutCmd = null;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandText = "ListerStatutCmd";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Connection = SqlConnection;

                SqlDataReader reader = sqlCmd.ExecuteReader();
                if (reader.Read())
                {
                    listStatutCmd = new List<Statut_Cmd>();
                    do
                    {
                        listStatutCmd.Add(
                            new Statut_Cmd(
                                Convert.ToInt32(reader["id"]),
                                Convert.ToString(reader["intitule"]))
                        );
                    } while (reader.Read());
                }

                reader.Close();
            }
            catch (Exception e)
            {

                throw new ExceptionAccesBD(e.Message);
            }
            

            return listStatutCmd;
        }
    }
}
