using System.Collections.Generic;
using System.Data.SqlClient;

namespace BodyRockyWPF.Model.DAO
{
    class BaseDao<T>
    {
        protected SqlConnection SqlConnection = null;

        /// <summary>
        /// Constructeur de base pour la classe BaseDao
        /// </summary>
        /// <param name="sqlConnection">La connexion à la BD</param>
        public BaseDao(SqlConnection sqlConnection)
        {
            SqlConnection = sqlConnection;
        }

        /// <summary>
        /// Retourne l'entité d'id
        /// </summary>
        /// <param name="id">L'id de l'entité à récupérer en BD</param>
        /// <returns>L'entité d'id</returns>
        public virtual T Charger(int id)
        {
            return default;
        }

        /// <summary>
        /// Persiste l'entité en BD
        /// </summary>
        /// <param name="entite">L'entité à persisté en BD</param>
        /// <returns>True si persisté sinon False</returns>
        public virtual bool Ajouter(T entite)
        {
            return false;
        }

        /// <summary>
        /// Modifie l'entité en BD
        /// </summary>
        /// <param name="entite">L'entité à modifié en BD</param>
        /// <returns>True si l'entité est modifié en BD sinon False</returns>

        public virtual bool Modifier(T entite)
        {
            return false;
        }

        /// <summary>
        /// Suppression physique de l'objet en BD
        /// </summary>
        /// <param name="id">Id de l'objet à supprimer en BD</param>
        /// <returns>True si l'objet est supprimé sinon False</returns>        
        public virtual bool Supprimer(int id)
        {
            return false;
        }

        /// <summary>
        /// Retourne la liste des toutes les entités
        /// </summary>
        /// <returns>La liste des entités</returns>
        public virtual List<T> ListerTous()
        {
            return null;
        }

    }
}
