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
    class CommandeDAO : BaseDao<Commande>
    {
        public CommandeDAO(SqlConnection sqlConnection) : base(sqlConnection) { }

        public override List<Commande> ListerTous()
        {
            List<Commande> listeCommande = null;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandText = "ListerCommande";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Connection = SqlConnection;

                SqlDataReader reader = sqlCmd.ExecuteReader();
                if (reader.Read())
                {
                    listeCommande = new List<Commande>();
                    do
                    {

                        listeCommande.Add(
                            new Commande(
                                Convert.ToInt32(reader["id_c"]),
                                new Adresse(
                                    Convert.ToInt32(reader["id_liv"]),
                                    Convert.ToString(reader["rue_liv"]),
                                    Convert.ToString(reader["numero_liv"]),
                                    Convert.ToString(reader["cp_liv"]),
                                    Convert.ToString(reader["ville_liv"])
                                    ),
                                new Adresse(
                                    Convert.ToInt32(reader["id_fac"]),
                                    Convert.ToString(reader["rue_fac"]),
                                    Convert.ToString(reader["numero_fac"]),
                                    Convert.ToString(reader["cp_fac"]),
                                    Convert.ToString(reader["ville_fac"])
                                    ),
                                new Statut_Cmd(
                                    Convert.ToInt32(reader["statut_id"]),
                                    Convert.ToString(reader["intitule"])
                                    ),
                                new Utilisateur(
                                    Convert.ToInt32(reader["id_u"]),
                                    reader["nom"] is DBNull ? null : Convert.ToString(reader["nom"]),
                                    reader["prenom"] is DBNull ? null : Convert.ToString(reader["prenom"]),
                                    reader["ddn"] is DBNull ? DateTime.Today : Convert.ToDateTime(reader["ddn"]),
                                    Convert.ToString(reader["email"]),
                                    null,
                                    Convert.ToBoolean(reader["actif"]),
                                    new List<Adresse>()
                                    ),
                                new Dictionary<Produit, int>()
                                )
                            );
                    } while (reader.Read());
                }

                reader.Close();

                if (listeCommande != null && listeCommande.Count > 0)
                {
                    listeCommande.ForEach(c => ChercherProduit(c));
                }

            }
            catch (Exception e)
            {
                throw new ExceptionAccesBD(e.Message);
            }

            return listeCommande;
        }
        public void ChercherProduit(Commande commande)
        {
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandText = "ListerProduitCommande";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Connection = SqlConnection;


                sqlCmd.Parameters.Add("@id_cmd", SqlDbType.Int).Value = commande.IdCommande;


                SqlDataReader reader = sqlCmd.ExecuteReader();
                if (reader.Read())
                {
                    do
                    {
                        commande.Produits.Add(
                            new Produit(
                                Convert.ToInt32(reader["id_produit"]),
                                Convert.ToString(reader["intitule"]),
                                Convert.ToString(reader["description"]),
                                Convert.ToDecimal(reader["prix"])
                                ),
                            Convert.ToInt32(reader["quantite_produit"])
                            );
                    } while (reader.Read());
                }
                reader.Close();
            }
            catch (Exception e)
            {
                throw new ExceptionAccesBD(e.Message);
            }
        }

        public bool ModifierStatutCmd(Commande entite)
        {
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandText = "ModifierStatutCmd";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Connection = SqlConnection;

                sqlCmd.Parameters.Add("@idStatutCmd", SqlDbType.Int).Value = entite.Statut.IdStatutCmd;
                sqlCmd.Parameters.Add("@idCmd", SqlDbType.Int).Value = entite.IdCommande;
                sqlCmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                sqlCmd.ExecuteNonQuery();

                return Convert.ToInt32(sqlCmd.Parameters["@RetVal"].Value.ToString()) > 0;
            }
            catch (Exception e)
            {
                throw new ExceptionAccesBD(e.Message);
            }
        }

        public bool AjoutHistorisationCmd(Commande entite)
        {
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandText = "AjoutHistoriqueCmdStatutCmd";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Connection = SqlConnection;

                sqlCmd.Parameters.Add("@dateModif", SqlDbType.DateTime).Value = DateTime.Now;
                sqlCmd.Parameters.Add("@idStatutCmd", SqlDbType.Int).Value = entite.Statut.IdStatutCmd;
                sqlCmd.Parameters.Add("@idCmd", SqlDbType.Int).Value = entite.IdCommande;
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
