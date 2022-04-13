using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace InfotoolsMobile 
{
    public class RdvComCli : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string client_id;
        private string employe_id;
        private DateTime daterdv;
        private Client client;
        private Employe employe;

        [JsonProperty("client_id")] //This maps the element title of your web service to your model
        public string ClientId
        {
            get => client_id;
            set
            {
                client_id = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        [JsonProperty("employe_id")] //This maps the element title of your web service to your model
        public string EmployeId
        {
            get => employe_id;
            set
            {
                employe_id = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        [JsonProperty("DateRdv")] //This maps the element title of your web service to your model
        public DateTime DateRdv
        {
            get => daterdv;
            set
            {
                daterdv = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        public Client Client
        {
            get { return client; }
            set { client = value; }
        }
        public Employe Employe
        {
            get { return employe; }
            set { employe = value; }
        }

        //This is how you create your OnPropertyChanged() method
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
