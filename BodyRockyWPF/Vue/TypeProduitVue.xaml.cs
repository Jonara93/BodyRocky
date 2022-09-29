using BodyRockyWPF.Controller;
using BodyRockyWPF.Model.model;
using BodyRockyWPF.Presenter.ExceptionUtil;
using BodyRockyWPF.Presenter.Utilitaire;
using BodyRockyWPF.Vue.Utilitaire;
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
    /// Interaction logic for TypeProduitVue.xaml
    /// </summary>
    public partial class TypeProduitVue : Page
    {
        public TypeProduitVue()
        {
            InitializeComponent();
            this.DataContext = new TypeProduitPresenter();
        }

        private void AjouterTypeProduit_Click(object sender, RoutedEventArgs e)
        {
            TypeProduitPresenter presenter = (TypeProduitPresenter)this.DataContext;
            Popup popupDialog = new Popup("Intitulé du TypeProduit","Ajout TypeProduit", null);
            if (popupDialog.ShowDialog() == true)
            {
                try
                {
                    TypeProduit tp = new TypeProduit(UtilitaireMetier.TransformeString(popupDialog.Answer));

                    if (ValidateurUtil.IsTypeCategorieValidEtPasExistant(tp, new List<TypeProduit>(presenter.CollectionTypeProduit)))
                    {
                        MessageBox.Show(presenter.AjouterTypeProduit(tp));
                    }
                    else
                    {
                        MessageBox.Show("L'intitule n'est pas valide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (ExceptionMetier exc)
                {
                    MessageBox.Show(exc.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("L'intitule n'est pas valide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
        }
    }
}
