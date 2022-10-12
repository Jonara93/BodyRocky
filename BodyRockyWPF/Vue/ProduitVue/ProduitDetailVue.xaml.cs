using BodyRockyWPF.Model.metier;
using BodyRockyWPF.Presenter;
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
        public ProduitDetailVue(Produit produit)
        {
            InitializeComponent();
            this.DataContext = new ProduitDetailPresenter(produit, true);
        }

        private void FermerFenetre_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(null);
        }
    }
}
