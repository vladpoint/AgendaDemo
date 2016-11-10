using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Windows.UI.Popups;
using AgendaDemo;

namespace AgendaDemo.UWP
{
    public sealed partial class MainPage: Login
    {
        private MobileServiceUser user;
        MobileServiceClient client = new MobileServiceClient(Conexion.conexion);
        public async Task<bool> Authenticate()
        {
            var success = false;
            try
            {
                user = await client.LoginAsync(MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory);
                if (user != null)
                {
                    success = true;
                    await new MessageDialog(user.UserId, "Bienvenido").ShowAsync();
                }
            }
            catch (Exception ex)
            {
                await new MessageDialog(ex.Message, "Error message").ShowAsync();
            }
            return success;
        }
        public MainPage()
        {
            this.InitializeComponent();
            AgendaDemo.App.Init((Login)this);
            LoadApplication(new AgendaDemo.App());
        }
    }
}
