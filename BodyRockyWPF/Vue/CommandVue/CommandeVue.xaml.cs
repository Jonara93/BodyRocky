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
    /// Interaction logic for CommandeVue.xaml
    /// </summary>
    public partial class CommandeVue : Page
    {
        public CommandeVue()
        {
            InitializeComponent();
            this.DataContext = new CommandePresenter();
        }

        private void GrilleCommande_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                CommandePresenter presenter = (CommandePresenter)this.DataContext;
                if (e.AddedItems != null && e.AddedItems.Count >= 1 && e.AddedItems[0] is Commande)
                {
                    presenter.Commande = e.AddedItems[0] as Commande;
                    CommandeViewSec.Content = new CommandeDetailVue(presenter, e.AddedItems[0] as Commande, true);
                }
                else
                {
                    CommandeViewSec.Content = null;
                }
            }
            catch (Exception m)
            {

                throw new ExceptionMetier(m.Message);
            }
        }

        private void ModifierCommande_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CommandePresenter presenter = (CommandePresenter)this.DataContext;
                if (presenter.Commande != null)
                {
                    CommandeViewSec.Content = new CommandeDetailVue(presenter, presenter.Commande, false);
                }
                else
                {
                    string message = "Veuillez choisir une commande à modifier.";
                    MessageBox.Show(message, "Erreur Metier", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception m)
            {

                throw new ExceptionMetier(m.Message);
            }
        }
    }
}
