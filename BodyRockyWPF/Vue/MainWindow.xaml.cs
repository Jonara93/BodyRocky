﻿using BodyRockyWPF.Model.DAO;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                FabriqueDao.GetInstance().CreerConnexion();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Liste_TypeProduits(object sender, RoutedEventArgs e)
        {
            try
            {
                Main.Content = new TypeProduitVue();
            }
            catch (Exception)
            {
                MessageBox.Show("Une erreur est survenue durant l'ouverture du composant \"TypeProduit\"");
            }
        }

        private void Liste_Produits(object sender, RoutedEventArgs e)
        {
            try
            {
                Main.Content = new TypeProduitVue();
            }
            catch (Exception)
            {
                MessageBox.Show("Une erreur est survenue durant l'ouverture du composant \"Produit\"");
            }
        }
    }
}
