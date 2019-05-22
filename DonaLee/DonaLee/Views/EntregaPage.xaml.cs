using iParking.Models;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace iParking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntregaPage : ContentPage
    {
        public Libro _libro { get; set; }
        conection conection = new conection();
        public ICommand EntregaCommand { get; }
        public EntregaPage()    
        {
            InitializeComponent();
            //EntregaCommand = new Command(() => Device.OpenUri( new Uri ("https://api.whatsapp.com/send?phone=+573133980136&text=Hola%20quiero%20ese%20libro%20%22Perro%20come%20perro%22")));


        }
        public EntregaPage(Libro _libroLoquiero)
        {

            InitializeComponent();
            _libro = new Libro
            {
                Titulo__c = ""

            };
            _libro = _libroLoquiero;
            BindingContext = this;
            //Uri newUri = new Uri("https://api.whatsapp.com/send?phone="+_libroLoquiero.idUser+"&text= Hola amigo mio");
            //EntregaCommand = new Command(() => Device.OpenUri(newUri));

        }        
        private async void BtnUpdateBook(object sender, EventArgs e)
        {
            await conection.UpdateBookByID(_libro, Convert.ToInt32(txtID.Text));
            txtID.Text = string.Empty;           
            await DisplayAlert("Gracias", "Libro Entregado", "OK");
            
           // await Navigation.PushModalAsync(new MisLibrosPage());

        }
        //private async void BtnRetrive_Clicked(object sender, EventArgs e)
        //{
        //    var libro = await conection.GetUser("");
        //    if (libro != null)
        //    {
        //        txtId.Text = libro.IdUsuario.ToString();
        //        txtName.Text = libro.NombresUsuario;
        //        await DisplayAlert("Success", "User Retrive Successfully", "OK");

        //    }
        //    else
        //    {
        //        await DisplayAlert("Success", "No User Available", "OK");
        //    }

        //}

    }
}