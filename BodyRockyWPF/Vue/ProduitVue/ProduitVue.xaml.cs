using BodyRockyWPF.Model.metier;
using BodyRockyWPF.Presenter;
using BodyRockyWPF.Presenter.ExceptionUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BodyRockyWPF.Vue
{
    /// <summary>
    /// Interaction logic for ProduitVue.xaml
    /// </summary>
    public partial class ProduitVue : Page
    {
        public ProduitVue()
        {
            InitializeComponent();
            this.DataContext = new ProduitPresenter();
        }

        private void AjouterProduit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProduitPresenter presenter = (ProduitPresenter)this.DataContext;
                ProduitViewSec.Content = new ProduitDetailVue(null, false, presenter.ListeProduit, (ProduitPresenter)this.DataContext);
            }
            catch (Exception m)
            {

                throw new ExceptionMetier(m.Message); ;
            }
        }

        private void GrilleCollectionProduit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ProduitPresenter presenter = (ProduitPresenter)this.DataContext;
                if (e.AddedItems != null && e.AddedItems.Count >= 1 && e.AddedItems[0] is Produit)
                {
                    presenter.Produit = e.AddedItems[0] as Produit;
                    ProduitViewSec.Content = new ProduitDetailVue(e.AddedItems[0] as Produit, true, presenter.ListeProduit, (ProduitPresenter)this.DataContext);
                }else
                {
                    ProduitViewSec.Content = null;
                }
            }
            catch (Exception m)
            {

                throw new ExceptionMetier(m.Message);
            }
        }

        private void ModifierProduit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProduitPresenter presenter = (ProduitPresenter)this.DataContext;
                if (presenter.Produit != null && presenter.Produit.Actif)
                {
                    ProduitViewSec.Content = new ProduitDetailVue(presenter.Produit, false, presenter.ListeProduit, (ProduitPresenter)this.DataContext);
                }
                else
                {
                    string message;
                    message = presenter.Produit == null ? "Veuillez choisir un produit" : "Le produit est inactif";
                    MessageBox.Show(message, "Erreur Metier", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception m)
            {

                throw new ExceptionMetier(m.Message); ;
            }
        }
    }
}
