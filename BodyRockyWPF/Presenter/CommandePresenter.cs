using BodyRockyWPF.Model.DAO;
using BodyRockyWPF.Model.metier;
using BodyRockyWPF.Presenter.Utilitaire;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyRockyWPF.Presenter
{
    public class CommandePresenter : INotifyPropertyChanged
    {
        ObservableCollection<Commande> collectionCommande;
        public List<Commande> ListeCommande { get; set; }
        public Commande Commande { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public CommandePresenter()
        {
            collectionCommande = new ObservableCollection<Commande>();
            ReloadCollectionCommande();
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

        public ObservableCollection<Commande> CollectionCommande
        {
            get
            {
                return collectionCommande;
            }
            set
            {
                collectionCommande = value;
                OnPropertyChanged("CollectionCommande");
            }
        }

        public void ReloadCollectionCommande()
        {
            List<Commande> listBDCommande = FabriqueDao.GetInstance().GetCommandeDao().ListerTous();

            if (ValidateurUtil.IsListNotNullAndNotEmpty(listBDCommande))
            {
                CollectionCommande = new ObservableCollection<Commande>(listBDCommande);
                ListeCommande = listBDCommande;
            }
            else
            {
                CollectionCommande = new ObservableCollection<Commande>();
            }
        }
    }
}
