using BodyRockyWPF.Model.DAO;
using BodyRockyWPF.Model.ExceptionUtil;
using BodyRockyWPF.Model.metier;
using BodyRockyWPF.Presenter.Utilitaire;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyRockyWPF.Presenter
{
    class CommandeDetailPresenter : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public String ViewMode { get; set; }
        public String EditMode { get; set; }
        public String TitrePage { get; set; }

        DataView dataViewStatutCmd;
        DataRowView dataRowViewStatutCmd;
        List<Statut_Cmd> listStatutCmd;
        public Commande Commande { get; set; }
        public Statut_Cmd StatutCmdInitial { get; set; }

        public CommandeDetailPresenter(Commande commande, Boolean isViewMode)
        {
            InjectionDonneeCommande(commande);


            ViewMode = isViewMode ? "Visible" : "Hidden";
            EditMode = isViewMode ? "Hidden" : "Visible";
            if (isViewMode)
            {
                if (commande != null)
                {
                    TitrePage = "Commande Numéro " + commande.IdCommande;
                }
            }
            else
            {
                TitrePage = "Modification Commande Numéro " + commande.IdCommande;
                InitDataViewStatutCmd();
            }
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

        //Propiété de la vue

        //Adresse livraison
        public String RueLiv
        {
            get { return this.Commande.AdresseLivraison.Rue; }
            set
            {
                this.Commande.AdresseLivraison.Rue = value;
                OnPropertyChanged("RueLiv");
            }
        }
        public String NumeroLiv
        {
            get { return this.Commande.AdresseLivraison.NumeroRue; }
            set
            {
                this.Commande.AdresseLivraison.NumeroRue = value;
                OnPropertyChanged("NumeroLiv");
            }
        }
        public String CpLiv
        {
            get { return this.Commande.AdresseLivraison.Cp; }
            set
            {
                this.Commande.AdresseLivraison.Cp = value;
                OnPropertyChanged("CpLiv");
            }
        }
        public String VilleLiv
        {
            get { return this.Commande.AdresseLivraison.Ville; }
            set
            {
                this.Commande.AdresseLivraison.Ville = value;
                OnPropertyChanged("VilleLiv");
            }
        }
        //Adresse Facturation
        public String RueFac
        {
            get { return this.Commande.AdresseFacturation.Rue; }
            set
            {
                this.Commande.AdresseFacturation.Rue = value;
                OnPropertyChanged("RueFac");
            }
        }
        public String NumeroFac
        {
            get { return this.Commande.AdresseFacturation.NumeroRue; }
            set
            {
                this.Commande.AdresseFacturation.NumeroRue = value;
                OnPropertyChanged("NumeroFac");
            }
        }
        public String CpFac
        {
            get { return this.Commande.AdresseFacturation.Cp; }
            set
            {
                this.Commande.AdresseFacturation.Cp = value;
                OnPropertyChanged("CpFac");
            }
        }
        public String VilleFac
        {
            get { return this.Commande.AdresseFacturation.Ville; }
            set
            {
                this.Commande.AdresseFacturation.Ville = value;
                OnPropertyChanged("VilleFac");
            }
        }

        public DataView DataViewStatutCmd
        {
            get
            {
                return dataViewStatutCmd;
            }
            set
            {
                dataViewStatutCmd = value;
                OnPropertyChanged("DataViewStatutCmd");
            }
        }
        public DataRowView SelectionStatutCmd
        {
            get { return dataRowViewStatutCmd; }
            set
            {
                dataRowViewStatutCmd = value;
                MettreAJourStatutCmd(value);
                OnPropertyChanged("SelectionStatutCmd");
            }
        }

        public String IntituleStatutCmd
        {
            get
            {
                return Commande.Statut.Intitule;
            }
        }

        public String NomPrenom
        {
            get
            {
                return Commande.Utilisateur.NomPrenom;
            }
        }

        public Dictionary<Produit, int> ProduitsCommands
        {
            get
            {
                return Commande.Produits;
            }
        }

        public String PrixTotalCmd
        {
            get
            {
                return Commande.PrixTotal + " €";
            }
        }
        //Fin propriété de la vue

        public void InjectionDonneeCommande(Commande commande)
        {
            Commande = new Commande();
            if (commande != null)
            {
                Commande = commande;
                StatutCmdInitial = new Statut_Cmd(commande.Statut);
                if (Commande.AdresseLivraison == null)
                {
                    Commande.AdresseLivraison = new Adresse();
                }
                if (Commande.AdresseFacturation == null)
                {
                    Commande.AdresseFacturation = new Adresse();
                }
                if (Commande.Utilisateur == null)
                {
                    Commande.Utilisateur = new Utilisateur();
                }
                if (Commande.Produits == null)
                {
                    Commande.Produits = new Dictionary<Produit, int>();
                }
            }
        }

        public void InitDataViewStatutCmd()
        {
            DataTable dtStatutCmd = new DataTable();
            dtStatutCmd.Columns.Add("id");
            dtStatutCmd.Columns.Add("intitule");

            listStatutCmd = FabriqueDao.GetInstance().GetStatutCommandeDao().ListerTous();

            if (ValidateurUtil.IsListNotNullAndNotEmpty(listStatutCmd))
            {
                listStatutCmd.ForEach(sc =>
                {
                    DataRow drStatutCmd = dtStatutCmd.NewRow();
                    drStatutCmd["id"] = sc.IdStatutCmd;
                    drStatutCmd["intitule"] = sc.Intitule;
                    dtStatutCmd.Rows.Add(drStatutCmd);
                });
            }
            DataView dvStatutCmd = new DataView(dtStatutCmd);
            DataViewStatutCmd = dvStatutCmd;
        }

        private void MettreAJourStatutCmd(DataRowView value)
        {
            if (ValidateurUtil.IsListNotNullAndNotEmpty(listStatutCmd))
            {
                listStatutCmd.ForEach(
                    sc =>
                    {
                        if (sc.IdStatutCmd.Equals(Convert.ToInt32(value["id"])))
                        {
                            Commande.Statut = new Statut_Cmd(sc);
                        }
                    }
                );
            }
        }

        public bool ModifierCommande()
        {
            try
            {
                if (!FabriqueDao.GetInstance().GetAdresseDao().Modifier(Commande.AdresseLivraison))
                {
                    throw new ExceptionAccesBD("Erreur lors de la modification de l'adresse de livraison");
                }
                if (!FabriqueDao.GetInstance().GetAdresseDao().Modifier(Commande.AdresseFacturation))
                {
                    throw new ExceptionAccesBD("Erreur lors de la modification de l'adresse de facturation");
                }
                if (!Commande.Statut.Equals(StatutCmdInitial))
                {
                    if (!FabriqueDao.GetInstance().GetCommandeDao().ModifierStatutCmd(Commande))
                    {
                        throw new ExceptionAccesBD("Erreur lors du changement de statut");
                    }
                    if (!FabriqueDao.GetInstance().GetCommandeDao().AjoutHistorisationCmd(Commande))
                    {
                        throw new ExceptionAccesBD("Erreur lors de l'historisation du statut");
                    }
                }
            }
            catch (Exception e)
            {
                throw new ExceptionAccesBD(e.Message);
            }
            return true;
        }
    }
}
