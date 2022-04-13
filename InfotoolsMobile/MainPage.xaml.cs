using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using InfotoolsMobile;


namespace InfotoolsMobile
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

        }
        protected override async void OnAppearing()
        {
            string rdv_content = await App._client.GetStringAsync(App.UrlRdv);
            string emp_content = await App._client.GetStringAsync(App.UrlEmp);
            string cli_content = await App._client.GetStringAsync(App.UrlCli);

            List<Employe> ListEmployes = JsonConvert.DeserializeObject<List<Employe>>(emp_content); //Deserializes or converts JSON String into a collection of Post
            List<Client> ListClients = JsonConvert.DeserializeObject<List<Client>>(cli_content); //Deserializes or converts JSON String into a collection of Post
            List<RdvComCli> ListRendezVous = JsonConvert.DeserializeObject<List<RdvComCli>>(rdv_content); //Deserializes or converts JSON String into a collection of Post


            foreach (RdvComCli unRdv in ListRendezVous) 
            {
                unRdv.Employe = ListEmployes.Find(i => i.Id == Convert.ToInt32(unRdv.EmployeId));
                unRdv.Client = ListClients.Find(i => i.Id == Convert.ToInt32(unRdv.ClientId));
            }

            App.Employes = new ObservableCollection<Employe>(ListEmployes);
            App.Clients = new ObservableCollection<Client>(ListClients);
            App.RendezVous = new ObservableCollection<RdvComCli>(ListRendezVous); //Converting the List to ObservalbleCollection of Post

            lvwRdv.ItemsSource = App.RendezVous;
            
            base.OnAppearing();
        }

        /// <summary>
        /// Click event of the Add Button. It sends a POST request adding a Post object in the server and in the collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnAdd(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AjoutRdv ());            
        }

        /// <summary>
        /// Click event of the Update Button. It sends a PUT request updating the first Post object in the server and in the collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnUpdate(object sender, EventArgs e)
        {
            if (lvwRdv.SelectedItem != null)
            {
                await Navigation.PushAsync(new ModifRdv((RdvComCli)lvwRdv.SelectedItem));
            }
            else
            {
                await DisplayAlert("Erreur", "Selection un rendez-vous dans la list", "OK");
            }
        }

        /// <summary>
        /// Click event of the Delete Button. It sends a DELETE request removing the first Post object in the server and in the 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnDelete(object sender, EventArgs e)
        {
            if (lvwRdv.SelectedItem != null)
            {
                App.unRdvComCli = (RdvComCli)lvwRdv.SelectedItem;
                await App._client.DeleteAsync(App.UrlRdv + "/" + App.unRdvComCli.Id); //Send a DELETE request to the specified Uri as an asynchronous 
                App.RendezVous.Remove(App.unRdvComCli); //Removes the first occurrence of a specific object from the Post collection. This will be visible on the UI instantly
            }
            else
            {
                await DisplayAlert("Erreur", "Selection un objet dans la list", "OK");
            }
        }
    }
}
