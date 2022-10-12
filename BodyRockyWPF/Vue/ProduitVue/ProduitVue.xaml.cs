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

        }

        private void GrilleCollectionProduit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (e.AddedItems != null && e.AddedItems.Count >= 1)
                {
                    ProduitViewSec.Content = new ProduitDetailVue(e.AddedItems[0] as Produit);
                }
            }
            catch (Exception m)
            {

                throw new ExceptionMetier(m.Message);
            }
        }
    }
}
