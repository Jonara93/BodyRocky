using BodyRockyWPF.Model.DAO;
using BodyRockyWPF.Model.metier;
using BodyRockyWPF.Model.model;
using BodyRockyWPF.Presenter.ExceptionUtil;
using BodyRockyWPF.Presenter.Utilitaire;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyRockyWPF.Presenter
{
    public class ProduitDetailPresenter : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Produit Produit { get; set; }
        public String ViewMode { get; set; }
        public String EditMode { get; set; }
        public String SuppresionReactivationMode { get; set; }
        public String TitrePage { get; set; }
        public String TitreBoutonAjoutModif { get; set; }
        public String TitreBoutonSuppresionReactivation { get; set; }
        DataView dataViewTypeProduit;
        DataRowView dataRowViewTypeProduit;
        List<TypeProduit> listTypeProduit;
        List<Produit> listProduitExistant;

        public ProduitDetailPresenter() { }
        public ProduitDetailPresenter(Produit produit, bool isViewMode, List<Produit> listProduitExistant)
        {
            InjectionDonneeProduit(produit);
            this.listProduitExistant = listProduitExistant;
            ViewMode = isViewMode ? "Visible" : "Hidden";
            EditMode = isViewMode ? "Hidden" : "Visible";
            if (isViewMode)
            {
                if (produit != null)
                {
                    TitrePage = "Détails du Produit : " + produit.Intitule;
                }
            }
            else if (produit == null)
            {
                TitrePage = "Ajout d'un nouvel article";
            }
            else
            {
                TitrePage = "Modification du Produit : " + produit.Intitule;
            }

            if (!isViewMode)
            {
                TitreBoutonAjoutModif = produit == null ? "Ajouter" : "Valider";
                InitDataViewTypeProduit();
            }

            if (produit != null && produit.IdProduit > 0)
            {
                TitreBoutonSuppresionReactivation = produit.Actif ? "Supprimer" : "Réactiver";
                SuppresionReactivationMode = "Visible";
            }
            else
            {
                SuppresionReactivationMode = "Hidden";
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                {
                    this.PropertyChanged(this,
                        new PropertyChangedEventArgs(propertyName));
                }
            }
        }

        public DataView DataViewTypeProduit
        {

            get
            {
                return dataViewTypeProduit;
            }
            set
            {
                dataViewTypeProduit = value;
                OnPropertyChanged("DataViewTypeProduit");
            }
        }
        public DataRowView SelectionTypeProduit
        {
            get { return dataRowViewTypeProduit; }
            set
            {
                dataRowViewTypeProduit = value;
                MettreAJourTypeProduit(value);
                OnPropertyChanged("SelectionTypeProduit");
            }
        }



        public String Intitule
        {
            get { return this.Produit.Intitule; }
            set
            {
                this.Produit.Intitule = value;
                OnPropertyChanged("Intitule");
            }
        }

        public String Description
        {
            get { return this.Produit.Description; }
            set
            {
                this.Produit.Description = value;
                OnPropertyChanged("Description");
            }
        }

        public Decimal Prix
        {
            get { return this.Produit.Prix; }
            set
            {
                this.Produit.Prix = value;
                OnPropertyChanged("Prix");
            }
        }

        public int Quantite
        {
            get { return this.Produit.Quantite; }
            set
            {
                this.Produit.Quantite = value;
                OnPropertyChanged("Quantite");
            }
        }

        public String IntituleTypeProduit
        {
            get { return this.Produit.TypeProduit.Intitule; }
            set
            {
                this.Produit.TypeProduit.Intitule = value;
                OnPropertyChanged("IntituleTypeProduit");
            }
        }
        public void InjectionDonneeProduit(Produit produit)
        {
            Produit = new Produit();
            Produit.TypeProduit = new TypeProduit();

            if (produit != null)
            {
                Produit.IdProduit = produit.IdProduit;
                Produit.Intitule = produit.Intitule;
                Produit.Description = produit.Description;
                Produit.Prix = produit.Prix;
                Produit.Actif = produit.Actif;
                Produit.Quantite = produit.Quantite;
                if (produit.TypeProduit != null)
                {
                    Produit.TypeProduit.IdTypeProduit = produit.TypeProduit.IdTypeProduit;
                    Produit.TypeProduit.Intitule = produit.TypeProduit.Intitule;
                }
            }
            else
            {
                Produit.Actif = true;
            }
        }

        private void InitDataViewTypeProduit()
        {
            DataTable dtTypeProduit = new DataTable();
            dtTypeProduit.Columns.Add("id");
            dtTypeProduit.Columns.Add("intitule");

            listTypeProduit = FabriqueDao.GetInstance().GetTypeProduitDao().ListerTous();

            if (ValidateurUtil.IsListNotNullAndNotEmpty(listTypeProduit))
            {
                listTypeProduit.ForEach(tp =>
                {
                    DataRow drTypeProduit = dtTypeProduit.NewRow();
                    drTypeProduit["id"] = tp.IdTypeProduit;
                    drTypeProduit["intitule"] = tp.Intitule;
                    dtTypeProduit.Rows.Add(drTypeProduit);
                });
            }

            DataView dvTypeProduit = new DataView(dtTypeProduit);
            DataViewTypeProduit = dvTypeProduit;
        }

        public bool AjouterOuModifierProduit()
        {
            if (!ValidateurUtil.IsProduitValide(Produit))
            {
                throw new ExceptionMetier("Le produit n'est pas valide");
            }
            if (Produit.IdProduit.Equals(0) && !ValidateurUtil.IsProduitIntituleUnique(listProduitExistant, Produit))
            {
                throw new ExceptionMetier("Un produit est déjà existant avec cet intitule");
            }

            return Produit.IdProduit.Equals(0) ? FabriqueDao.GetInstance().GetProduitDao().Ajouter(Produit) :
                FabriqueDao.GetInstance().GetProduitDao().Modifier(Produit);
        }
        public bool SupprimerReactiverProduit()
        {
            return FabriqueDao.GetInstance().GetProduitDao().SupprimerReactiver(Produit);
        }

        private void MettreAJourTypeProduit(DataRowView value)
        {
            if (ValidateurUtil.IsListNotNullAndNotEmpty(listTypeProduit))
            {
                listTypeProduit.ForEach(
                    p =>
                        {
                            if (p.IdTypeProduit.Equals(Convert.ToInt32(value["id"])))
                            {
                                Produit.TypeProduit = new TypeProduit(p);
                            }
                        }
                    );
            }
            else
            {
                throw new ExceptionMetier("La liste des typeProduits est vide");
            }
        }


    }
}
