using iParking.Models;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace iParking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SolicitudPage : ContentPage
    {
        public ICommand OpenWaCommand { get; }

        public SolicitudPage()
        {
            InitializeComponent();
            webView.Source = "https://www.google.com/maps/search/?api=1&query=4.6420318,-74.0544994";

        }
        public SolicitudPage(Libro _libroLoquiero)
        {

            InitializeComponent();
            webView.Source = "https://www.google.com/maps/search/?api=1&query=4.6420318,-74.0544994";
            Uri newUri = new Uri("https://api.whatsapp.com/send?phone=+573133980136&text=Hola%20quiero%20ese%20libro%20+%20%22Perro%20come%20perro%22");
            // Uri newUri = new Uri ("https://api.whatsapp.com/send?phone="+ _libroLoquiero.idUser +"&text= Hola amigo mio");
            OpenWaCommand = new Command(() => Device.OpenUri(newUri));
            //Device.OpenUri(new Uri("https://api.whatsapp.com/send?phone=+573133980136&text=Hola%20quiero%20ese%20libro%20%22Perro%20come%20perro%22")));

        }
    }
}