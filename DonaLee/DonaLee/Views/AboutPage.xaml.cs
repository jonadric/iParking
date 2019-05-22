using iParking.Models;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace iParking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public ICommand OpenWaCommand { get; }

        public AboutPage()
        {
            InitializeComponent();
            

        }
        public AboutPage( Libro _libroLoquiero)
        {
            
            InitializeComponent();           
            Uri newUri = new Uri ("https://api.whatsapp.com/send?phone=+573133980136&text=Hola%20quiero%20ese%20libro%20+%20%22Perro%20come%20perro%22");
            // Uri newUri = new Uri ("https://api.whatsapp.com/send?phone="+ _libroLoquiero.idUser +"&text= Hola amigo mio");
            OpenWaCommand = new Command(() => Device.OpenUri(newUri));

        }
    }
}