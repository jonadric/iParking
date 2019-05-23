using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using iParking.ViewModels;

using iParking.Models;
using System.Linq;

namespace iParking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageNuevaDonacion : ContentPage
    {
        public Libro _libro { get; set; }
        public Vehiculo vehiculo { get; set; }

        conection conection = new conection();

      

        public PageNuevaDonacion()
        {

          

            InitializeComponent();
         

            vehiculo = new Vehiculo
            { color = "Blue" ,modelo ="Audi"
            };

            BindingContext = this;
            //BindingContext = new GenView();
        }

       

        async void Save_Clicked(object sender, EventArgs e)
        {
           // _libro.Genero = ListGeneros[pickerGenero.SelectedIndex].NameGen;

                await DisplayAlert("iParking", "Libro "+vehiculo.placa+" cargado.", "OK");
            // MessagingCenter.Send(this, "Añadir", _libro);
            
            var allBoks = await conection.GetAllBooks();
           // var CodBookNuevoGenerado = allBoks[allBoks.Count -1];
           // _libro.IdBook = CodBookNuevoGenerado.IdBook + 1;
            var valor = Application.Current.Properties["id_User"];
            await conection.AddBook(vehiculo, int.Parse(valor.ToString()));
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        

    }
}