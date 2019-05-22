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
    public partial class TestDBPage : ContentPage
    {
        public Usuario _user { get; set; }
        public String id { get; set; }
        conection conection = new conection();
        public TestDBPage()
        {
            InitializeComponent();
            getUser();

        }
        public async Task getUser()
        {

            _user = new Usuario
            {
                NombresUsuario = ""

            };
            var valor = Application.Current.Properties["id_User"];
            var User = await conection.GetUserById(int.Parse(valor.ToString()));

            id = valor.ToString();
            _user.NombresUsuario = User.NombresUsuario;            
            BindingContext = this;



        }

        // var valor = Application.Current.Properties["id_User"];

        //protected async override void OnAppearing()
        //{

        //    base.OnAppearing();
        //    var allUsers = await conection.GetAllUsers();
        //    lstUsers.ItemsSource = allUsers;
        //}

        //private async void BtnAdd_Clicked(object sender, EventArgs e)
        //{
        //    await conection.AddUser(txtId.Text, txtName.Text,"Cas","",5);
        //    txtId.Text = string.Empty;
        //    txtName.Text = string.Empty;
        //    await DisplayAlert("Success", "Person Added Successfully", "OK");
        //    var allUsers = await conection.GetAllUsers();
        //    lstUsers.ItemsSource = allUsers;
        //}

        //private async void BtnRetrive_Clicked(object sender, EventArgs e)
        //{
        //    var person = await conection.GetUser("");
        //    if (person != null)
        //    {
        //        txtId.Text = person.IdUsuario.ToString();
        //        txtName.Text = person.NombresUsuario;
        //        await DisplayAlert("Success", "User Retrive Successfully", "OK");

        //    }
        //    else
        //    {
        //        await DisplayAlert("Success", "No User Available", "OK");
        //    }

        //}

        //private async void BtnUpdate_Clicked(object sender, EventArgs e)
        //{
        //    await conection.UpdateUser(Convert.ToInt32(txtId.Text), txtName.Text);
        //    txtId.Text = string.Empty;
        //    txtName.Text = string.Empty;
        //    await DisplayAlert("Success", "Person Updated Successfully", "OK");
        //    var allUsers = await conection.GetAllUsers();
        //    lstUsers.ItemsSource = allUsers;
        //}

        //private async void BtnDelete_Clicked(object sender, EventArgs e)
        //{
        //    await conection.DeleteUser(Convert.ToInt32(txtId.Text));
        //    await DisplayAlert("Success", "Person Deleted Successfully", "OK");
        //    var allUsers = await conection.GetAllUsers();
        //    lstUsers.ItemsSource = allUsers;
        //}



    }
}