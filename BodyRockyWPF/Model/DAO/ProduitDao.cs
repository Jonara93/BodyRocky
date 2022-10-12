using BodyRockyWPF.Model.ExceptionUtil;
using BodyRockyWPF.Model.metier;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BodyRockyWPF.Model.model;

namespace BodyRockyWPF.Model.DAO
{
    class ProduitDao : BaseDao<Produit>
    {
        public ProduitDao(SqlConnection sqlConnection) : base(sqlConnection) { }

        public override Produit Charger(int id)
        {
            return base.Charger(id);
        }

        public override List<Produit> ListerTous()
        {
            List<Produit> listeProduit = null;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandText = "ListerProduit";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Connection = SqlConnection;

                SqlDataReader reader = sqlCmd.ExecuteReader();
                if (reader.Read())
                {
                    listeProduit = new List<Produit>();
                    do
                    {
                        listeProduit.Add(new Produit(
                                Convert.ToInt32(reader["id_produit"]),
                                Convert.ToString(reader["p_intitule"]),
                                Convert.ToString(reader["description"]),
                                new byte[10],//photo
                                Convert.ToDecimal(reader["prix"]),
                                Convert.ToBoolean(reader["actif"]),
                                new TypeProduit(Convert.ToInt32(reader["id_type_produit"]), Convert.ToString(reader["tp_intitule"]))
                            )
                        );
                    } while (reader.Read());
                }

                reader.Close();
            }
            catch (Exception e)
            {
                throw new ExceptionAccesBD(e.Message);
            }
            return listeProduit;
        }
    }
}
