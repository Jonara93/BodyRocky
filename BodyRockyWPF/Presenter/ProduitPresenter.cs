using BodyRockyWPF.Model.DAO;
using BodyRockyWPF.Model.metier;
using BodyRockyWPF.Model.model;
using BodyRockyWPF.Presenter.Utilitaire;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyRockyWPF.Presenter
{
    public class ProduitPresenter : INotifyPropertyChanged
    {
        ObservableCollection<Produit> collectionProduit;
        public List<Produit> ListeProduit { get; set; }

        DataView dataViewTypeProduit;
        DataRowView dataRowViewTypeProduit;
        public Produit Produit { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ProduitPresenter()
        {
            collectionProduit = new ObservableCollection<Produit>();
            InitDataViewTypeProduit();
            ReloadCollectionProduit();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs(propertyName));
                }
            }
        }

        public ObservableCollection<Produit> CollectionProduit
        {
            get { return collectionProduit; }
            set
            {
                collectionProduit = value;
                OnPropertyChanged("CollectionProduit");
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
                FiltrerListe(value);
                OnPropertyChanged("SelectionTypeProduit");
            }
        }

        public void ReloadCollectionProduit()
        {
            List<Produit> listBDProduit = FabriqueDao.GetInstance().GetProduitDao().ListerTous();

            if (listBDProduit != null && listBDProduit.Count > 0)
            {
                CollectionProduit = new ObservableCollection<Produit>(listBDProduit);
                ListeProduit = listBDProduit;
            }
            else
            {
                CollectionProduit = new ObservableCollection<Produit>();
            }
        }



        private void InitDataViewTypeProduit()
        {
            DataTable dtTypeProduit = new DataTable();
            dtTypeProduit.Columns.Add("id");
            dtTypeProduit.Columns.Add("intitule");

            DataRow drGeneric = dtTypeProduit.NewRow();
            drGeneric["id"] = "0";
            drGeneric["intitule"] = "--- Tous ---";
            dtTypeProduit.Rows.Add(drGeneric);

            List<TypeProduit> typeProduits = FabriqueDao.GetInstance().GetTypeProduitDao().ListerTous();

            if (ValidateurUtil.IsListNotNullAndNotEmpty(typeProduits))
            {
                typeProduits.ForEach(tp =>
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

        public void FiltrerListe(DataRowView drvTypeProduit)
        {
            if (Convert.ToInt32(drvTypeProduit["id"]).Equals(0))
            {
                if (ValidateurUtil.IsListNotNullAndNotEmpty(ListeProduit))
                {
                    CollectionProduit = new ObservableCollection<Produit>(ListeProduit);
                }
            }
            else
            {
                List<Produit> listProduitFiltrer = new List<Produit>();
                if (ValidateurUtil.IsListNotNullAndNotEmpty(ListeProduit))
                {
                    ListeProduit.ForEach(p =>
                        {
                            if (p.TypeProduit != null && p.TypeProduit.IdTypeProduit.Equals(Convert.ToInt32(drvTypeProduit["id"])))
                            {
                                listProduitFiltrer.Add(p);
                            }
                        }
                    );
                }
                CollectionProduit = new ObservableCollection<Produit>(listProduitFiltrer);
            }
        }
    }
}
