using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.MobileServices;

namespace AgendaDemo
{
    public class Agenda
    {
        string id;
        string nombre;
        string apellido;
        string telefono;
        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        [JsonProperty(PropertyName = "name")]
        public string Name
        {
            get { return nombre; }
            set { nombre = value; }
        }

        [JsonProperty(PropertyName = "lastname")]
        public string Lastname
        {
            get { return apellido; }
            set { apellido = value; }
        }

        [JsonProperty(PropertyName = "cellphone")]
        public string Cellphone
        {
            get { return telefono; }
            set { telefono = value; }
        }
        [Version]
        public string Version { get; set; }


    }
}
