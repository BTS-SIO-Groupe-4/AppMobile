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

namespace InfotoolsMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModifRdv : ContentPage
    {
        RdvComCli rdvModif;

        public ModifRdv(RdvComCli rdv)
        {
            InitializeComponent();
            rdvModif = rdv;

            ClientPiker.ItemsSource = App.Clients;
            EmployePiker.ItemsSource = App.Employes;

            DateRdv.Date = rdvModif.DateRdv;
            ClientPiker.SelectedItem = rdvModif.Client; 
            EmployePiker.SelectedItem = rdvModif.Employe; 
        }

        /// <summary>
        /// Click event of the Update Button. It sends a PUT request updating the first Post object in the server and in the collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnUpdate(object sender, EventArgs e)
        {
            Client ClientSelect = (Client)ClientPiker.SelectedItem;
            Employe EmployeSelect = (Employe)EmployePiker.SelectedItem;
            DateTime dt = DateRdv.Date;
            dt = Convert.ToDateTime(dt.ToString("yyyy-MM-dd"));

            RdvComCli rdv = new RdvComCli { DateRdv = dt, ClientId = ClientSelect.Id.ToString(), EmployeId = EmployeSelect.Id.ToString(), Client = null, Employe = null };

            string content = JsonConvert.SerializeObject(rdv); //Serializes or convert the created Post into a JSON String
            HttpResponseMessage response = null;
            response = await App._client.PutAsync(App.UrlRdv + "/" + rdvModif.Id, new StringContent(content, Encoding.UTF8, "application/json")); //Send a PUT request to the specified Uri as an asynchronous operation.

            if (response.IsSuccessStatusCode)
            {
                await Navigation.PushAsync(new MainPage());
            }
        }
    }
}