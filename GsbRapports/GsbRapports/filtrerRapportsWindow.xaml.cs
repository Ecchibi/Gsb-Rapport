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
using System.IO;
using System.Xml.Serialization;

namespace GsbRapports
{
    /// <summary>
    /// Logique d'interaction pour filtrerRapportsWindow.xaml
    /// </summary>
    public partial class filtrerRapportsWindow : Window
    {
        private Secretaire laSecretaire;
        private WebClient wb;
        private string site;
        public filtrerRapportsWindow(Secretaire laSecretaire, WebClient wb, string site)
        {
            InitializeComponent();
            this.laSecretaire = laSecretaire;
            this.site = site;
            this.wb = wb;

            //VISITEUR on cree la liste 
            dynamic url = this.site + "visiteurs?ticket=" + this.laSecretaire.getHashTicketMdp();
            string data = this.wb.DownloadString(url);
            dynamic d = JsonConvert.DeserializeObject(data);//on convertie l'url en donnée json pour la recup
            string visiteur = d.visiteurs.ToString();
            string ticket = d.ticket;
            this.laSecretaire.ticket = ticket; // tjr recup le ticket et le donner a la secretaire
            List<Visiteur> l = JsonConvert.DeserializeObject<List<Visiteur>>(visiteur); //on crée la liste d'elements
            this.cmbVisiteur.ItemsSource = l;
            this.cmbVisiteur.DisplayMemberPath = "concat";

            //MEDECIN on cree la liste de tout les medecins 
            //et apres dans "txtMedecin_KeyUp"on recup a partir du debut du nom 
            url = this.site + "medecins?ticket=" + this.laSecretaire.getHashTicketMdp() + "&nom=" + this.txtMedecin.Text.ToString();
    
            data = this.wb.DownloadString(url);
            dynamic d2 = JsonConvert.DeserializeObject(data);
            string medecins = d2.medecins.ToString();
            ticket = d2.ticket;
            this.laSecretaire.ticket = ticket;
            List<Medecin> lm = JsonConvert.DeserializeObject<List<Medecin>>(medecins);
            this.cmbMedecin.ItemsSource = lm;
            this.cmbMedecin.DisplayMemberPath = "concat";

        }

        private void txtQuantite_KeyUp(object sender, KeyEventArgs e)
        {
            dynamic url = this.site + "medecins?ticket=" + this.laSecretaire.getHashTicketMdp() + "&nom=" + this.txtMedecin.Text.ToString();
            string data = this.wb.DownloadString(url);
            dynamic d2 = JsonConvert.DeserializeObject(data);
            string medecins = d2.medecins.ToString();
            string ticket = d2.ticket;
            this.laSecretaire.ticket = ticket;
            List<Medecin> lm = JsonConvert.DeserializeObject<List<Medecin>>(medecins);
            this.cmbMedecin.ItemsSource = lm;
            this.cmbMedecin.DisplayMemberPath = "concat";
        }

        private void cmbVisiteur_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            string idVisiteur = ((Visiteur)cmbVisiteur.SelectedItem).id.ToString();
            string url = this.site + "rapports?ticket=" + this.laSecretaire.getHashTicketMdp() + "&idVisiteur=" + idVisiteur;
            string data = this.wb.DownloadString(url);
            dynamic d = JsonConvert.DeserializeObject(data);//on convertie l'url en donnée json pour la recup
            string rapports = d.rapports.ToString();
            string ticket = d.ticket;
            this.laSecretaire.ticket = ticket; // tjr recup le ticket et le donner a la secretaire
            List<Rapport> l = JsonConvert.DeserializeObject<List<Rapport>>(rapports); //on crée la liste d'elements
            this.dtg.ItemsSource = l;
           
        }

        private void btnValider_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.dateDebut.Text.ToString() == "" || this.dateFin.Text.ToString() == "")
                {
                    MessageBox.Show("Un ou plusieurs champs sont vides !", "Champ(s) manquant(s)", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    string dateDebut = this.dateDebut.Text.ToString();
                    string dateFin = this.dateFin.Text.ToString();

                    DateTime dTime = Convert.ToDateTime(dateDebut);
                    string dateTime = dTime.ToString("yyyy-MM-dd");
                    DateTime dTime2 = Convert.ToDateTime(dateFin);
                    string dateTime2 = dTime2.ToString("yyyy-MM-dd");
                    //string dateTime = dTime.ToShortDateString().Replace('/', '-');

                    string url = this.site + "rapports?ticket=" + this.laSecretaire.getHashTicketMdp() + "&dateDebut=" + dateTime
                        + "&dateFin=" + dateTime2;

                    string data = this.wb.DownloadString(url);
                    dynamic d = JsonConvert.DeserializeObject(data);
                    string rapports = d.rapports.ToString();
                    string ticket = d.ticket;
                    this.laSecretaire.ticket = ticket;
                    List<Rapport> l = JsonConvert.DeserializeObject<List<Rapport>>(rapports);
                    this.dtg.ItemsSource = l;
                }
            }
            catch (WebException ex)//afficher lerreur si n'ajoute pas
            {
                if (ex.Response is HttpWebResponse)
                    MessageBox.Show(((HttpWebResponse)ex.Response).StatusCode.ToString());
            }
        }

        private void cmbMedecin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            
            string idMedecin = ((Medecin)cmbMedecin.SelectedItem).id.ToString();
            string url = this.site + "rapports?ticket=" + this.laSecretaire.getHashTicketMdp() + "&idMedecin=" + idMedecin;
            string data = this.wb.DownloadString(url);
            dynamic d = JsonConvert.DeserializeObject(data);//on convertie l'url en donnée json pour la recup
            string rapports = d.rapports.ToString();
            string ticket = d.ticket;
            this.laSecretaire.ticket = ticket; // tjr recup le ticket et le donner a la secretaire
            List<Rapport> l = JsonConvert.DeserializeObject<List<Rapport>>(rapports); //on crée la liste d'elements
            this.dtg.ItemsSource = l;
        
        }

        private void btnSeria_Click(object sender, RoutedEventArgs e)
        {
            try
            {   // sis champ pas vide serialize 
                if (this.cmbVisiteur.SelectedItem != null)
                {
                    //dtg.Items.Refresh();   JE VOULAIS EFFACER LE DTG...
                    //dtg.Items.Clear();
                    //cmbMedecin.Items.Clear();
                    //cmbMedecin.SelectedIndex = -1;
                    string idVisiteur = ((Visiteur)cmbVisiteur.SelectedItem).id.ToString();
                    string url = this.site + "rapports?ticket=" + this.laSecretaire.getHashTicketMdp() + "&idVisiteur=" + idVisiteur;
                    string data = this.wb.DownloadString(url);
                    dynamic d = JsonConvert.DeserializeObject(data);//on convertie l'url en donnée json pour la recup
                    string rapports = d.rapports.ToString();
                    string ticket = d.ticket;
                    this.laSecretaire.ticket = ticket; // tjr recup le ticket et le donner a la secretaire
                    List<Rapport> lv = JsonConvert.DeserializeObject<List<Rapport>>(rapports); //on crée la liste d'elements

                    FileStream fichier = new FileStream("rapportsParVisiteur.xml", FileMode.Create);
                    XmlSerializer xml = new XmlSerializer(lv.GetType());
                    xml.Serialize(fichier, lv);
                    MessageBox.Show("Fichier Créer", "Succès", MessageBoxButton.OK, MessageBoxImage.Information); 
                }


                if (this.cmbMedecin.SelectedItem != null)
                {
           
                    //string url = this.site + "medecins?ticket=" + this.laSecretaire.getHashTicketMdp() + "&nom=" + this.txtMedecin.Text.ToString();
                    string idMedecin = ((Medecin)cmbMedecin.SelectedItem).id.ToString();
                    string url = this.site + "rapports?ticket=" + this.laSecretaire.getHashTicketMdp() + "&idMedecin=" + idMedecin;

                    string data = this.wb.DownloadString(url);
                    dynamic d2 = JsonConvert.DeserializeObject(data);
                    string rapports = d2.rapports.ToString();
                    string ticket = d2.ticket;
                    this.laSecretaire.ticket = ticket;
                    List<Rapport> lm = JsonConvert.DeserializeObject<List<Rapport>>(rapports);

                    FileStream fichier = new FileStream("rapportsParMedecin.xml", FileMode.Create);
                    XmlSerializer xml = new XmlSerializer(lm.GetType());
                    xml.Serialize(fichier, lm);
                    MessageBox.Show("Fichier Créer", "Succès", MessageBoxButton.OK, MessageBoxImage.Information); 
                }

                if (this.dateDebut.Text.ToString() != "" && this.dateFin.Text.ToString() != "")
                {
                    
                    string dateDebut = this.dateDebut.Text.ToString();
                    string dateFin = this.dateFin.Text.ToString();
                    DateTime dTime = Convert.ToDateTime(dateDebut);
                    string dateTime = dTime.ToString("yyyy-MM-dd");
                    DateTime dTime2 = Convert.ToDateTime(dateFin);
                    string dateTime2 = dTime2.ToString("yyyy-MM-dd");

                    string url = this.site + "rapports?ticket=" + this.laSecretaire.getHashTicketMdp() + "&dateDebut=" + dateTime
                        + "&dateFin=" + dateTime2;

                    string data = this.wb.DownloadString(url);
                    dynamic d = JsonConvert.DeserializeObject(data);

                    string rapports = d.rapports.ToString();
                    string ticket = d.ticket;
                    this.laSecretaire.ticket = ticket;
                    List<Rapport> ld = JsonConvert.DeserializeObject<List<Rapport>>(rapports);

                    FileStream fichier = new FileStream("rapportsParDate.xml", FileMode.Create);
                    XmlSerializer xml = new XmlSerializer(ld.GetType());
                    xml.Serialize(fichier, ld);
                    MessageBox.Show("Fichier Créer", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
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
