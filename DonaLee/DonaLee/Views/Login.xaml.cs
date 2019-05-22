using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iParking.Models;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace iParking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        conection conection = new conection();
        public Usuario UserApp;
        public Login()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var allUsers = await conection.GetAllUsers();
            //lstUsers.ItemsSource = allUsers;
        }

        async private void BtnEnter_Clicked(Object sender, EventArgs e)
        {
            UserApp = await conection.GetUser(txtCorreo.Text);
            if (UserApp != null)
            {
                if (txtContrasenia.Text == UserApp.ContraseniaUsuario)
                {
                    await DisplayAlert("iParking", "Bienvenido ahora puedes reservar un parqueadero", "OK");
                    App.Current.Properties["id_User"] = UserApp.IdUsuario.ToString();
                    App.Current.MainPage = new MainPage();
                }
                else
                {
                    await DisplayAlert("Error", "Contraseña incorrecta", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "Usuario invalido", "OK");
            }
        }

         private void BtnToReg_Clicked(object sender, EventArgs e)
        {

             Navigation.PushModalAsync(new Registro());
        }

    }
}