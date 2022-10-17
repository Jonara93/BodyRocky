using BodyRockyWPF.Model.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BodyRockyWPF.Model.ExceptionUtil;

namespace BodyRockyWPF.Model.DAO
{
    class TypeProduitDao : BaseDao<TypeProduit>
    {
        /// <summary>
        /// Constructeur de base
        /// </summary>
        /// <param name="sqlConnection">La connexion BD</param>
        public TypeProduitDao(SqlConnection sqlConnection) : base(sqlConnection) { }

        public override List<TypeProduit> ListerTous()
        {
            List<TypeProduit> typeProduits = null;
            SqlCommand sqlCmd = new SqlCommand();

            try
            {
                sqlCmd.CommandText = "ListerTypeProduit";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Connection = SqlConnection;

                SqlDataReader reader = sqlCmd.ExecuteReader();

                if (reader.Read())
                {
                    typeProduits = new List<TypeProduit>();
                    do
                    {
                        typeProduits.Add(new TypeProduit(Convert.ToInt32(reader["id_type_produit"]),
                                                      Convert.ToString(reader["intitule"])));
                    } while (reader.Read());
                }

                reader.Close();
            }
            catch (Exception e)
            {
                throw new ExceptionAccesBD(e.Message);
            }

            return typeProduits;
        }

        public override TypeProduit Charger(int id)
        {
            TypeProduit typeProduit = null;

            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandText = "GetTypeProduitParId";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Connection = SqlConnection;

                SqlDataReader reader = sqlCmd.ExecuteReader();

                if (reader.Read())
                {
                    typeProduit = new TypeProduit(
                            Convert.ToInt32(reader["id_type_produit"]),
                            Convert.ToString(reader["intitule"])
                        );
                }

                reader.Close();
            }
            catch (Exception e)
            {
                throw new ExceptionAccesBD(e.Message);
            }
            return typeProduit;
        }

        public override bool Ajouter(TypeProduit entite)
        {
            SqlCommand sqlCmd = new SqlCommand();

            try
            {
                sqlCmd.CommandText = "AjouterTypeProduit";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Connection = SqlConnection;
                sqlCmd.Parameters.Add("@Intitule", SqlDbType.VarChar).Value = entite.Intitule;
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
