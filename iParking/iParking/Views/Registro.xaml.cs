using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iParking.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace iParking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        conection conection = new conection();
        public Registro()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var allUsers = await conection.GetAllUsers();
            //lstUsers.ItemsSource = allUsers;
        }

        private async void BtnRegistrar(Object sender, EventArgs args)
        {
            var User = await conection.GetUser(txtCorreo.Text);
            if (User != null)
            {
                await DisplayAlert("Error", "El usuario ya esta registrado con este correo", "OK");
            }
            else
            {

                var allUsers1 = await conection.GetAllUsers();
                var CodNuevoGenerado = allUsers1.Last(); 
                CodNuevoGenerado.IdUsuario = CodNuevoGenerado.IdUsuario +1;

                await conection.AddUser(txtCorreo.Text, txtNombre.Text,txtApellido.Text,txtContrasenia.Text, CodNuevoGenerado.IdUsuario);
                txtCorreo.Text = string.Empty;
                txtNombre.Text = string.Empty;
                txtApellido.Text = string.Empty;
                txtContrasenia.Text = string.Empty;
                await DisplayAlert("Registrado", "Usuario registrado", "OK");
                await Navigation.PushModalAsync(new Login());

            }
        }
                
    }

}