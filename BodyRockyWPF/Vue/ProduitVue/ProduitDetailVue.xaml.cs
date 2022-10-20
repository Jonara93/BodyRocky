using BodyRockyWPF.Model.ExceptionUtil;
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
    /// Interaction logic for ProduitDetailVue.xaml
    /// </summary>
    public partial class ProduitDetailVue : Page
    {
        ProduitPresenter produitPresenter;
        public ProduitDetailVue(Produit produit, Boolean isViewMode, List<Produit> listProduitExistant, ProduitPresenter produitPresenterEnvoye)
        {
            InitializeComponent();
            this.DataContext = new ProduitDetailPresenter(produit, isViewMode, listProduitExistant);
            produitPresenter = produitPresenterEnvoye;
        }

        private void FermerFenetre_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(null);
        }

        private void AjouterModifierProduit_Click(object sender, RoutedEventArgs e)
        {
            ProduitDetailPresenter presenter = (ProduitDetailPresenter)this.DataContext;
            try
            {
                if (presenter.AjouterOuModifierProduit())
                {
                    produitPresenter.ReloadCollectionProduit();
                    MessageBox.Show("Everything is alright", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.Navigate(null);
                }
                else
                {
                    MessageBox.Show("Une erreur est survenue", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (ExceptionMetier m)
            {
                MessageBox.Show(m.Message, "Erreur Metier", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (ExceptionAccesBD m)
            {
                MessageBox.Show(m.Message, "Erreur DB", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SuppressionReactivationProduit_Click(object sender, RoutedEventArgs e)
        {
            ProduitDetailPresenter presenter = (ProduitDetailPresenter)this.DataContext;
            try
            {
                if (presenter.SupprimerReactiverProduit())
                {
                    produitPresenter.ReloadCollectionProduit();
                    MessageBox.Show("Action effectué", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.Navigate(null);
                }
                else
                {
                    MessageBox.Show("Une erreur est survenue", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (ExceptionMetier m)
            {
                MessageBox.Show(m.Message, "Erreur Metier", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (ExceptionAccesBD m)
            {
                MessageBox.Show(m.Message, "Erreur DB", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
