using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace InfotoolsMobile
{
    public class Employe : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string nom_emp;
        private string prenom_emp;

        [JsonProperty("NomEmp")] //This maps the element title of your web service to your model
        public string Nom
        {
            get => nom_emp;
            set
            {
                nom_emp = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        [JsonProperty("PrenomEmp")] //This maps the element title of your web service to your model
        public string Prenom
        {
            get => prenom_emp;
            set
            {
                prenom_emp = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        public string String
        {
            get { return Id + " - " + Nom + " " + Prenom; }
            private set { }
        }

        //This is how you create your OnPropertyChanged() method
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
