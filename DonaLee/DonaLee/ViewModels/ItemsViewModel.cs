using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using iParking.Models;
using iParking.Views;

namespace iParking.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        conection conection = new conection();

        public ObservableCollection<Libro> ItemsBooks { get; set; }
        public Command LoadItemsCommand { get; set; }

         public ItemsViewModel()
        {
            Title = "iParking";
            ItemsBooks = new ObservableCollection<Libro>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ///VAMOS A LLENAR DESDE UN COMIENZO
            ///
          //  llenarDeComienzo();

            //MessagingCenter.Subscribe<PageNuevoVehiculo, Libro>(this, "AddBook", async (obj, item) =>
            //{
            //    var newItem = item as Libro;
            //    newItem.Autor__c = "jejejej";
            //    ItemsBooks.Add(newItem);
            //    await DataStore.AddItemAsync(newItem);
            //});
        }

        async Task llenarDeComienzo() {
            var allBoks = await conection.GetAllBooks();
            foreach (var libro in allBoks)
            {
                ItemsBooks.Add(libro);
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
                var allBoks = await conection.GetAllBooks();


                //var items = await DataStore.GetItemsAsync(true);
                foreach (var libro in allBoks)
                {
                    ItemsBooks.Add(libro);
                }
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