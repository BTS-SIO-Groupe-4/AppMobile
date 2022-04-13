using System;
using Xamarin.Forms;
using System.Net.Http;
using System.Collections.ObjectModel;

namespace InfotoolsMobile
{
    public partial class App : Application
    {
        public static string UrlRdv = "http://10.0.2.2/api-infotools/public/api/rdvcomcli";
        public static string UrlEmp = "http://10.0.2.2/api-infotools/public/api/employes";
        public static string UrlCli = "http://10.0.2.2/api-infotools/public/api/clients";
        public static readonly HttpClient _client = new HttpClient();
        public static ObservableCollection<RdvComCli> RendezVous { get;  set; }
        public static ObservableCollection<Employe> Employes { get;  set; }
        public static ObservableCollection<Client> Clients { get; set; }

        public static RdvComCli unRdvComCli;

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
