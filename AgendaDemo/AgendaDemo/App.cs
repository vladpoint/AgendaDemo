using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace AgendaDemo
{
    public class App : Application
    {
        public static Login Authenticator { get; private set; }
        public static void Init(Login authenticator)
        {
            Authenticator = authenticator;
        }
        public App()
        {
            // The root page of your application
            MobileServiceClient client;
            IMobileServiceTable<Agenda> tabla;
            client = new MobileServiceClient(Conexion.conexion);
            tabla = client.GetTable<Agenda>();
            Label titulo = new Label()
            {
                Text = "Insertar datos:"
            };
            Entry nombre1 = new Entry();
            Entry apellido1 = new Entry();
            Entry telefono1 = new Entry();
            Button enviar = new Button()
            {
                Text = "enviar datos"
            };
            Button leer = new Button()
            {
                Text = "leer Tabla"
            };
            Button login = new Button()
            {
                Text = "login"
            };
            login.Clicked += async (sender, args) =>
            {
                bool authenticated = false;
                authenticated = await App.Authenticator.Authenticate();
            };
            ListView lista = new ListView();
            ListView lista2 = new ListView();
            leer.Clicked += async (sender, args) =>
            {
                IEnumerable<Agenda> items = await tabla
    .ToEnumerableAsync();
                string[] arreglo = new string[items.Count()];
                string[] arreglo2 = new string[items.Count()];
                int i = 0;
                foreach (var x in items)
                {
                    arreglo[i] = x.Name;
                    arreglo2[i] = x.Lastname;
                    i++;
                }
                lista.ItemsSource = arreglo;
                lista2.ItemsSource = arreglo2;
            };
            enviar.Clicked += async (sender, args) =>
            {
                var datos = new Agenda { Name = nombre1.Text, Lastname = apellido1.Text, Cellphone = telefono1.Text };
                await tabla.InsertAsync(datos);
                IEnumerable<Agenda> items = await tabla
    .ToEnumerableAsync();
                string[] arreglo = new string[items.Count()];
                string[] arreglo2 = new string[items.Count()];
                int i = 0;
                foreach (var x in items)
                {
                    arreglo[i] = x.Name;
                    arreglo2[i] = x.Lastname;
                    i++;
                }
                lista.ItemsSource = arreglo;
                lista2.ItemsSource = arreglo2;
            };
            Button actualizar = new Button()
            {
                Text = "Eliminar dato"
            };
            actualizar.Clicked += async (sender, args) =>
            {
                IEnumerable<Agenda> items = await tabla
    .ToEnumerableAsync();
                string[] arreglo = new string[items.Count()];
                string[] arreglo2 = new string[items.Count()];
                string[] ids = new string[items.Count()];
                string[] arreglo3 = new string[items.Count()];
                int i = 0;
                foreach (var x in items)
                {
                    arreglo[i] = x.Name;
                    arreglo2[i] = x.Lastname;
                    ids[i] = x.Id;
                    arreglo3[i] = x.Cellphone;
                    if (x.Cellphone == telefono1.Text)
                    {
                        if(x.Name != nombre1.Text)
                        {
                            x.Name = nombre1.Text;
                        }
                        if(x.Lastname != apellido1.Text)
                        {
                            x.Lastname = apellido1.Text;
                        }
                        await tabla.DeleteAsync(x);
                    }
                    i++;
                }
                lista.ItemsSource = arreglo;
                lista2.ItemsSource = arreglo2;
            };
            var layout = new StackLayout();
            layout.Children.Add(titulo);
            layout.Children.Add(nombre1);
            layout.Children.Add(apellido1);
            layout.Children.Add(telefono1);
            layout.Children.Add(login);
            layout.Children.Add(enviar);
            layout.Children.Add(leer);
            layout.Children.Add(actualizar);
            layout.Children.Add(lista);
            layout.Children.Add(lista2);
            MainPage = new ContentPage
            {
                Content = layout
            };
        }

        protected async override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
