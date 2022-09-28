using BodyRockyWPF.Model.DAO;
using BodyRockyWPF.Model.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyRockyWPF.Controller
{
    class TypeProduitPresenter : INotifyPropertyChanged
    {
        ObservableCollection<TypeProduit> collectionTypeProduit;

        public event PropertyChangedEventHandler PropertyChanged;
        public TypeProduit typeProduit { get; set; }

        public TypeProduitPresenter()
        {
            collectionTypeProduit = new ObservableCollection<TypeProduit>();
            ReloadCollectionTypeProduit();
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

        public ObservableCollection<TypeProduit> CollectionTypeProduit
        {
            get { return collectionTypeProduit; }
            set
            {
                collectionTypeProduit = value;
                OnPropertyChanged("CollectionTypeProduit");
            }
        }

        private void ReloadCollectionTypeProduit()
        {
            List<TypeProduit> typeProduits = FabriqueDao.GetInstance().GetTypeProduitDao().ListerTous();

            if (typeProduits != null && typeProduits.Count > 0)
            {
                CollectionTypeProduit = new ObservableCollection<TypeProduit>(typeProduits);
            }
            else
            {
                CollectionTypeProduit = new ObservableCollection<TypeProduit>();
            }
        }

        internal string AjouterTypeProduit(TypeProduit tp)
        {
            string result;

            if (FabriqueDao.GetInstance().GetTypeProduitDao().Ajouter(tp))
            {
                result = tp.Intitule + " a bien été sauvegardé.";
            }
            else
            {
                result = "Une erreur est survenue durant la sauvegarde";
            }

            ReloadCollectionTypeProduit();

            return result;
        }
    }
}
