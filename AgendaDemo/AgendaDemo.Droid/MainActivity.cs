using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using AgendaDemo;
using AgendaDemo.Droid;

namespace AgendaDemo.Droid
{
    [Activity(Label = "AgendaDemo", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity, Login
    {
        private MobileServiceUser user;
        MobileServiceClient client = new MobileServiceClient(Conexion.conexion);
        public async Task<bool> Authenticate()
        {
            var success = false;
            try
            {
                user = await client.LoginAsync(this, MobileServiceAuthenticationProvider.Facebook);
                if (user != null)
                {
                    success = true;
                }
            }
            catch(Exception ex)
            {
                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                builder.SetMessage(ex.Message);
                builder.SetTitle("Error message");
                builder.Create().Show();
            }
            return success;
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
            global::Xamarin.Forms.Forms.Init(this, bundle);
            App.Init((Login)this);
            LoadApplication(new App());
        }
    }
}

