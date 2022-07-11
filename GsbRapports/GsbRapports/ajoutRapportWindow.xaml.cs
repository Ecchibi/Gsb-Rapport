using dllRapportVisites;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;//pour le preview text input avoir seulement des chiffre 
using System.Windows;
using System.Windows.Input;

namespace GsbRapports
{
    /// <summary>
    /// Logique d'interaction pour ajoutRapportsWindow.xaml
    /// </summary>
    public partial class ajoutRapportWindow : Window
    {
        private Secretaire laSecretaire;
        private WebClient wb;
        private string site;

        public ajoutRapportWindow(Secretaire laSecretaire, WebClient wb, string site)
        {
            InitializeComponent();
            this.laSecretaire = laSecretaire;
            this.site = site;
            this.wb = wb;
            this.cmbMedicament2.Visibility = Visibility.Hidden;
            this.txtQuantite2.Visibility = Visibility.Hidden;
            this.lstMedecin3.Visibility = Visibility.Hidden;
            this.btnPlus.Visibility = Visibility.Visible;
            this.btnMoins.Visibility = Visibility.Hidden;


            //VISITEUR on cree la liste 
            dynamic url = this.site + "visiteurs?ticket=" + this.laSecretaire.getHashTicketMdp();
            string data = this.wb.DownloadString(url);
            dynamic d = JsonConvert.DeserializeObject(data);//on convertie l'url en donnée json pour la recup
            string visiteur = d.visiteurs.ToString();
            string ticket = d.ticket;
            this.laSecretaire.ticket = ticket; // tjr recup le ticket et le donner a la secretaire
            List<Visiteur> l = JsonConvert.DeserializeObject<List<Visiteur>>(visiteur); //on crée la liste d'elements
            this.cmbVisiteur.ItemsSource = l; //affiche tout les element 
            this.cmbVisiteur.DisplayMemberPath = "concat"; //affiche un element definie "concat"


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


            //MEDICAMENTS affiche la liste entiere
            url = this.site + "medicaments?ticket=" + this.laSecretaire.getHashTicketMdp();
            data = this.wb.DownloadString(url);
            dynamic d3 = JsonConvert.DeserializeObject(data);
            string medicaments = d3.medicaments.ToString();
            ticket = d3.ticket;
            this.laSecretaire.ticket = ticket;
            List<Medicament> lmedic = JsonConvert.DeserializeObject<List<Medicament>>(medicaments);
            this.cmbMedicament.ItemsSource = lmedic;
            this.cmbMedicament.DisplayMemberPath = "nomCommercial";
            this.cmbMedicament2.ItemsSource = lmedic;
            this.cmbMedicament2.DisplayMemberPath = "nomCommercial";
            this.cmbMedicament3.ItemsSource = lmedic;
            this.cmbMedicament3.DisplayMemberPath = "nomCommercial";
            this.txtQuantite.Text = null;
            this.txtQuantite2.Text = null;
            this.txtQuantite3.Text = null;

        }

        //Affiche les medecin a partir du debut du nom 
        private void txtMedecin_KeyUp(object sender, KeyEventArgs e)
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

        private void btnValider_Click_1(object sender, RoutedEventArgs e)
        {//ici on ajoute de Rapport en reucperant les donnée entrer dans le formuaire 
            try
            {
               

                //condition si champs vide 
                if (this.datePicker.Text.ToString() == "" || cmbVisiteur.SelectedItem == null ||
                    cmbMedecin.SelectedItem == null || cmbMedicament.SelectedItem == null || txtQuantite.Text.ToString() == "" ||
                    txtMotif.Text.ToString() == "" || txtBilan.Text.ToString() == "" )
                {
                    MessageBox.Show("Un ou plusieurs champs sont vides !","Champ(s) manquant(s)", MessageBoxButton.OK, MessageBoxImage.Error);
                
                }
                else
                {

                //on convertis le format date MM/dd/yyyy en yyyy-MM-dd pour la base de donneé ↓
                string date = datePicker.Text.ToString();
                DateTime dTime = Convert.ToDateTime(date);
                string dateTime = dTime.ToString("yyyy-MM-dd");

                string url = this.site + "rapports";
                string ticket = this.laSecretaire.getHashTicketMdp();
                //string idMed1 = ((Medicament)this.cmbMedicament.SelectedItem).id.ToString();
                

                NameValueCollection parametres = new NameValueCollection();
                parametres.Add("ticket", ticket);
                parametres.Add("date", dateTime);
                parametres.Add("idVisiteur", ((Visiteur)this.cmbVisiteur.SelectedItem).id.ToString());
                parametres.Add("idMedecin", ((Medecin)this.cmbMedecin.SelectedItem).id.ToString());                         
                parametres.Add("motif", this.txtMotif.Text);
                parametres.Add("bilan", this.txtBilan.Text);

                if (this.cmbMedicament.SelectedItem != null && this.txtQuantite.Text != null)
                {
                     //controle saisie E-5
                    if(this.cmbMedicament.SelectedItem == this.cmbMedicament2.SelectedItem)
                    { 
                        MessageBoxResult result;
                        result = MessageBox.Show("Voulez vous ajouter cette quantité","Controle Saisie", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (result == MessageBoxResult.Yes)
                        {
                                int total = Convert.ToInt32(this.txtQuantite.Text) + Convert.ToInt32(this.txtQuantite2.Text);
                                string totalString = total.ToString();
                                MessageBox.Show(totalString , "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                                string idSameMedicament1 = ((Medicament)this.cmbMedicament.SelectedItem).id.ToString();
                                parametres.Add("medicaments[" + idSameMedicament1 + "]", totalString);
                                this.txtQuantite2.Text = null;
                                this.cmbMedicament2.SelectedItem = null;
                        }

                            else
                            {
                                this.Close();
                            }
                        }
                    else{ 
                            string idMed1 = ((Medicament)this.cmbMedicament.SelectedItem).id.ToString();
                            parametres.Add("medicaments[" + idMed1 + "]", this.txtQuantite.Text); //dans l'API → medicaments[<idMed>] = <qte>
                        }
                    }



                if (this.cmbMedicament2.SelectedItem != null && this.txtQuantite2.Text != null)
                {
                    string idMed2 = ((Medicament)this.cmbMedicament2.SelectedItem).id.ToString();
                    parametres.Add("medicaments[" + idMed2 + "]", this.txtQuantite2.Text); //dans l'API → medicaments[<idMed>] = <qte>
                }
               
                if (this.cmbMedicament3.SelectedItem != null && this.txtQuantite3.Text != null)
                {
                    string idMed3 = ((Medicament)this.cmbMedicament3.SelectedItem).id.ToString();
                    parametres.Add("medicaments[" + idMed3 + "]", this.txtQuantite3.Text);//dans l'API → medicaments[<idMed>] = <qte>
                }
            

                    byte[] tabByte = wb.UploadValues(url, parametres);
                    string ticketS = UnicodeEncoding.UTF8.GetString(tabByte);
                    MessageBox.Show("Rapport Ajouter", "Succès", MessageBoxButton.OK, MessageBoxImage.Information); //si ajouter nous affiche ...
                    this.laSecretaire.ticket = ticketS.Substring(2); //enleve les deux \n du ticket
                }

            }


            catch (WebException ex)//afficher lerreur si n'ajoute pas
            {
                if (ex.Response is HttpWebResponse)
                    MessageBox.Show(((HttpWebResponse)ex.Response).StatusCode.ToString());

            }


        }








        private void btnPlus_Click(object sender, RoutedEventArgs e)
        { 
            this.cmbMedicament2.Visibility = Visibility.Visible;
            this.txtQuantite2.Visibility = Visibility.Visible;
            this.lstMedecin3.Visibility = Visibility.Visible;
            this.btnPlus.Visibility = Visibility.Hidden;
            this.btnMoins.Visibility = Visibility.Visible;
        }

        private void btnMoins_Click(object sender, RoutedEventArgs e)
        {
            this.cmbMedicament2.Visibility = Visibility.Hidden;
            this.txtQuantite2.Visibility = Visibility.Hidden;
            this.lstMedecin3.Visibility = Visibility.Hidden;
            this.btnMoins.Visibility = Visibility.Hidden;
            this.btnPlus.Visibility = Visibility.Visible;
        }

        private void txtQuantite_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtQuantite2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtQuantite3_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }



        //private void txtDate_GotFocus(object sender, RoutedEventArgs e)
        //{
        //    if (this.txtDate.Text != "")
        //    {
        //          txtDate.ForeColor = Color.Gray;
        //          this.txtDate.Text = ""; 
        //    }
        //}

        //private void txtDate_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    if (this.txtDate.Text == "")
        //    {
        //        this.txtDate.Text = "AAAA-MM-JJ";
        //    }
        //}
    }
}
