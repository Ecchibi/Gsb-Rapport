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
using System.Windows.Shapes;
using dllRapportVisites;
using Newtonsoft.Json;
using System.Net;
using System.Collections.Specialized;


namespace GsbRapports
{
    /// <summary>
    /// Logique d'interaction pour modifierRapportsWindow.xaml
    /// </summary>
    public partial class modifierRapportsWindow : Window
    {
        private Secretaire laSecretaire;
        private WebClient wb;
        private string site;
        public modifierRapportsWindow(Secretaire laSecretaire, WebClient wb, string site)
        {
            InitializeComponent();
            this.laSecretaire = laSecretaire;
            this.site = site;
            this.wb = wb;

            dynamic url = this.site + "visiteurs?ticket=" + this.laSecretaire.getHashTicketMdp();
            string data = this.wb.DownloadString(url);
            dynamic d = JsonConvert.DeserializeObject(data);
            string visiteur = d.visiteurs.ToString();
            string ticket = d.ticket;
            this.laSecretaire.ticket = ticket;
            List<Visiteur> l = JsonConvert.DeserializeObject<List<Visiteur>>(visiteur);
            this.cmbVisiteur.ItemsSource = l;
            this.cmbVisiteur.DisplayMemberPath = "concat";
        }

        private void cmbVisiteur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string idVisiteur = ((Visiteur)cmbVisiteur.SelectedItem).id.ToString();
            string url = this.site + "rapports?ticket=" + this.laSecretaire.getHashTicketMdp() + "&idVisiteur=" + idVisiteur;
            string data = this.wb.DownloadString(url);
            dynamic d = JsonConvert.DeserializeObject(data);
            string rapports = d.rapports.ToString();
            string ticket = d.ticket;
            this.laSecretaire.ticket = ticket;
            List<Rapport> l = JsonConvert.DeserializeObject<List<Rapport>>(rapports);
            this.dtg.ItemsSource = l;
            this.dtg.DisplayMemberPath = "concatMedecin";
            this.cmbDate.ItemsSource = l;
            this.cmbDate.DisplayMemberPath = "date";

        }
        private void btnChercher_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.cmbDate.Text.ToString() == "" )
                {
                    MessageBox.Show("Un ou plusieurs champs sont vides !", "Champ(s) manquant(s)", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    string idVisiteur = ((Visiteur)cmbVisiteur.SelectedItem).id.ToString();
                    string dateDebutFin = cmbDate.Text.ToString();
                    DateTime dTime = Convert.ToDateTime(dateDebutFin);
                    string dateTime = dTime.ToString("yyyy-MM-dd");
                    //string dateTime = dTime.ToShortDateString().Replace('/', '-');


                    string url = this.site + "rapports?ticket=" + this.laSecretaire.getHashTicketMdp() + "&idVisiteur=" + idVisiteur +
                         "&dateDebut=" + dateTime + "&dateFin=" + dateTime;


                    string data = this.wb.DownloadString(url);
                    dynamic d = JsonConvert.DeserializeObject(data);
                    string rapports = d.rapports.ToString();
                    string ticket = d.ticket;
                    this.laSecretaire.ticket = ticket;
                    List<Rapport> l = JsonConvert.DeserializeObject<List<Rapport>>(rapports);
                    this.dtg.ItemsSource = l;
                    this.dtg.DisplayMemberPath = "concatMedecin";
                }
                }
            catch (WebException ex)//afficher lerreur si n'ajoute pas
            {
                if (ex.Response is HttpWebResponse)
                    MessageBox.Show(((HttpWebResponse)ex.Response).StatusCode.ToString());
            }
        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                //condition si champs vides 
                if (txtMotif.Text.ToString() == "" || txtBilan.Text.ToString() == "")
                {
                    MessageBox.Show("Un ou plusieurs champs sont vides !", "Champ(s) manquant(s)", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                else
                {

                    string idRapport = ((Rapport)this.dtg.SelectedItem).idRapport.ToString(); //PROB = La référence d'objet n'est pas définie à une instance d'un objet.
                                                                                              //(valeur = NULL)
                    string url = this.site + "rapport/" + idRapport;
                    string ticket = this.laSecretaire.getHashTicketMdp();


                    NameValueCollection parametres = new NameValueCollection();
                    parametres.Add("ticket", ticket);
                    //parametres.Add("id",((Rapport)this.dtg.SelectedItem).id.ToString());
                    parametres.Add("motif", this.txtMotif.Text);
                    parametres.Add("bilan", this.txtBilan.Text);
                    byte[] tabByte = wb.UploadValues(url, parametres);
                    string ticketS = UnicodeEncoding.UTF8.GetString(tabByte);
                    MessageBox.Show("Modification Apportée", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                    this.laSecretaire.ticket = ticketS.Substring(2); //enleve les deux \n du ticket
                }
            }

            catch (WebException ex)
            {
                if (ex.Response is HttpWebResponse)
                    MessageBox.Show(((HttpWebResponse)ex.Response).StatusCode.ToString());

            }
        }


    }
}
