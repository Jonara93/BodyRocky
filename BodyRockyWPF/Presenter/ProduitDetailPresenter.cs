using BodyRockyWPF.Model.metier;
using BodyRockyWPF.Model.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public String TitrePage { get; set; }

        public ProduitDetailPresenter() { }
        public ProduitDetailPresenter(Produit produit, bool isViewMode)
        {
            InjectionDonneeProduit(produit);
            ViewMode = isViewMode ? "Visible" : "Hidden";
            EditMode = isViewMode ? "Hidden" : "Visible";
            TitrePage = isViewMode ? "Détails du Produit : " + produit.Intitule : "Ajout d'un nouvel article";
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
                Produit.Intitule = produit.Intitule;
                Produit.Description = produit.Description;
                Produit.Prix = produit.Prix;
                if (produit.TypeProduit != null)
                {
                    Produit.TypeProduit.Intitule = produit.TypeProduit.Intitule;
                }
            }
        }
    }
}
