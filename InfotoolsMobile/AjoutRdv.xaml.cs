using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace InfotoolsMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AjoutRdv : ContentPage
    {
        public AjoutRdv()
        {
            InitializeComponent();
            
            ClientPiker.ItemsSource = App.Clients;
            EmployePiker.ItemsSource = App.Employes;
        }

        /// <summary>
        /// Click event of the Add Button. It sends a POST request adding a Post object in the server and in the collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnAdd(object sender, EventArgs e)
        {

            Client ClientSelect = (Client)ClientPiker.SelectedItem;
            Employe EmployeSelect = (Employe)EmployePiker.SelectedItem;
            DateTime dt = DateRdv.Date;
            dt = Convert.ToDateTime(dt.ToString("yyyy-MM-dd"));
            RdvComCli rdv = new RdvComCli { DateRdv = dt, ClientId = ClientSelect.Id.ToString(), EmployeId = EmployeSelect.Id.ToString()}; //Creating a new instance of Post with a Title Property and its value in a Timestamp format        

            string content = JsonConvert.SerializeObject(rdv); //Serializes or convert the created Post into a JSON String

            HttpResponseMessage response = null;
            response = await App._client.PostAsync(App.UrlRdv,new StringContent(content, Encoding.UTF8, "application/json")); //Send a POST request to the specified Uri as an asynchronous operation and with correct character encoding (utf9) and contenct type (application/json).

            if (response.IsSuccessStatusCode)
            {
                App.RendezVous.Insert(0, rdv); //Updating the UI by inserting an element into the first index of the collection*/
                await Navigation.PushAsync(new MainPage());
            }            
        }
    }
}