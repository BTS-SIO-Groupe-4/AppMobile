using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace InfotoolsMobile
{
    public class Client : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string nom_cli;
        private string prenom_cli;


        [JsonProperty("NomCli")] //This maps the element title of your web service to your model
        public string Nom
        {
            get => nom_cli;
            set
            {
                nom_cli = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        [JsonProperty("PrenomCli")] //This maps the element title of your web service to your model
        public string Prenom
        {
            get => prenom_cli;
            set
            {
                prenom_cli = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        public string String
        {
            get { return Id + " - " + Nom + " " + Prenom; }
            private set {}
        }

        //This is how you create your OnPropertyChanged() method
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
