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
        conection conection = new conection();

       // public string[,] listaGeneros=[{"Aventura"];
        public List<Genero> ListGeneros { get; set; }
        public List<Genero> GetGeneros()
        {
             ListGeneros = new List<Genero>()
                {
                    new Genero(){  NameGen="Acción"},
                    new Genero(){  NameGen="Aventura"},
                    new Genero(){  NameGen="Romantica"},
                    new Genero(){  NameGen="Suspenso"}
                };
            return ListGeneros;
        }

        public PageNuevaDonacion()
        {

            //INICIALIZA LISTA DE GENEROS
           // listaGeneros = ["Aventura","Romatica"];
            InitializeComponent();
            pickerGenero.ItemsSource = GetGeneros().ToList();
            _libro = new Libro
            {
                Autor__c = "",
                Descripcion__c = "",
                Imagen__c="",
                Ubicacion=new Ubicacion()
            };

            BindingContext = this;
            //BindingContext = new GenView();
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            _libro.Genero = ListGeneros[pickerGenero.SelectedIndex].NameGen;

                await DisplayAlert("iParking", "Libro "+_libro.Titulo__c+" cargado.", "OK");
            // MessagingCenter.Send(this, "Añadir", _libro);
            
            var allBoks = await conection.GetAllBooks();
            var CodBookNuevoGenerado = allBoks[allBoks.Count -1];
            _libro.IdBook = CodBookNuevoGenerado.IdBook + 1;
            var valor = Application.Current.Properties["id_User"];
            await conection.AddBook(_libro, int.Parse(valor.ToString()));
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        

    }
}