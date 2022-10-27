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

namespace BodyRockyWPF.Vue.CommandVue
{
    /// <summary>
    /// Interaction logic for CommandeDetailVue.xaml
    /// </summary>
    public partial class CommandeDetailVue : Page
    {
        CommandePresenter commandePresenter;
        public CommandeDetailVue(CommandePresenter commandePresenter, Commande commande, Boolean isViewMode)
        {
            InitializeComponent();
            this.DataContext = new CommandeDetailPresenter(commande, isViewMode);
            this.commandePresenter = commandePresenter;
        }

        private void FermerFenetre_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(null);
        }

        private void ValideerModificationCommande_Click(object sender, RoutedEventArgs e)
        {
            CommandeDetailPresenter presenter = (CommandeDetailPresenter) DataContext;
            try
            {
                if (presenter.ModifierCommande())
                {
                    commandePresenter.ReloadCollectionCommande();
                    MessageBox.Show("Everything is alright", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                    //NavigationService.Navigate(null);
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
