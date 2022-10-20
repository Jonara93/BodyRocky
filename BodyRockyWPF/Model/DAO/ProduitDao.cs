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
                                new TypeProduit(Convert.ToInt32(reader["id_type_produit"]), Convert.ToString(reader["tp_intitule"])),
                                Convert.ToInt32(reader["quantite"])
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

        public override bool Ajouter(Produit entite)
        {
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandText = "AjouterProduit";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Connection = SqlConnection;

                sqlCmd.Parameters.Add("@Intitule", SqlDbType.VarChar).Value = entite.Intitule;
                sqlCmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = entite.Description;
                if (entite.Photo == null)
                {
                    sqlCmd.Parameters.Add("@photo", SqlDbType.VarBinary).Value = DBNull.Value;
                }
                else
                {
                    sqlCmd.Parameters.Add("@photo", SqlDbType.VarBinary).Value = entite.Photo;
                }
                sqlCmd.Parameters.Add("@Prix", SqlDbType.Decimal).Value = entite.Prix;
                sqlCmd.Parameters.Add("@Actif", SqlDbType.Bit).Value = entite.Actif;
                sqlCmd.Parameters.Add("@Quantite", SqlDbType.Int).Value = entite.Quantite;
                sqlCmd.Parameters.Add("@id_type_produit", SqlDbType.Int).Value = entite.TypeProduit.IdTypeProduit;
                sqlCmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                sqlCmd.ExecuteNonQuery();

                return Convert.ToInt32(sqlCmd.Parameters["@RetVal"].Value.ToString()) > 0;
            }
            catch (Exception e)
            {

                throw new ExceptionAccesBD(e.Message);
            }
        }

        public override bool Modifier(Produit entite)
        {
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandText = "ModifierProduit";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Connection = SqlConnection;

                sqlCmd.Parameters.Add("@id_produit", SqlDbType.Int).Value = entite.IdProduit;
                sqlCmd.Parameters.Add("@Intitule", SqlDbType.VarChar).Value = entite.Intitule;
                sqlCmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = entite.Description;
                if (entite.Photo == null)
                {
                    sqlCmd.Parameters.Add("@photo", SqlDbType.VarBinary).Value = DBNull.Value;
                }
                else
                {
                    sqlCmd.Parameters.Add("@photo", SqlDbType.VarBinary).Value = entite.Photo;
                }
                sqlCmd.Parameters.Add("@Prix", SqlDbType.Decimal).Value = entite.Prix;
                sqlCmd.Parameters.Add("@Quantite", SqlDbType.Int).Value = entite.Quantite;
                sqlCmd.Parameters.Add("@id_type_produit", SqlDbType.Int).Value = entite.TypeProduit.IdTypeProduit;
                sqlCmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                sqlCmd.ExecuteNonQuery();

                return Convert.ToInt32(sqlCmd.Parameters["@RetVal"].Value.ToString()) > 0;
            }
            catch (Exception e)
            {
                throw new ExceptionAccesBD(e.Message);
            }
        }

        public bool SupprimerReactiver(Produit entite)
        {
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandText = "SupprimerReactiverProduit";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Connection = SqlConnection;

                sqlCmd.Parameters.Add("@id_produit", SqlDbType.Int).Value = entite.IdProduit;
                sqlCmd.Parameters.Add("@actif", SqlDbType.Bit).Value = !entite.Actif;
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
