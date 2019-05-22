using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using iParking.Models;

namespace iParking.ViewModels
{
    class MisLibrosModel : BaseViewModel

    {
        conection conection = new conection();

        public ObservableCollection<Libro> ItemsBooks { get; set; }
        public Command LoadItemsCommand { get; set; }

        public MisLibrosModel()
        {
            Title = "MisCarros";
            ItemsBooks = new ObservableCollection<Libro>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

        }

        async Task llenarDeComienzo()
        {
            var allBoks = await conection.GetAllBooks();
            foreach (var libro in allBoks)
            {
                var valor = Application.Current.Properties["id_User"];
                if (libro.idUser==valor.ToString())
                {
                    ItemsBooks.Add(libro);

                }
            }
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                ItemsBooks.Clear();
                await llenarDeComienzo();
                //var allBoks = await conection.GetAllBooks();
                ////var items = await DataStore.GetItemsAsync(true);
                //foreach (var libro in allBoks)
                //{
                //    ItemsBooks.Add(libro);
                //}
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
