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

        public ObservableCollection<Vehiculo> ItemsBooks { get; set; }
        public Command LoadItemsCommand { get; set; }

         public ItemsViewModel()
        {
            Title = "iParking";
            ItemsBooks = new ObservableCollection<Vehiculo>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ///VAMOS A LLENAR DESDE UN COMIENZO
            ///
          //  llenarDeComienzo();

            //MessagingCenter.Subscribe<PageNuevoVehiculo, Libro>(this, "AddVehicles", async (obj, item) =>
            //{
            //    var newItem = item as Libro;
            //    newItem.Autor__c = "jejejej";
            //    ItemsVehicles.Add(newItem);
            //    await DataStore.AddItemAsync(newItem);
            //});
        }

        async Task llenarDeComienzo() {
            var allVehiculos = await conection.GetAllVehicles();
            foreach (var _vehiculo in allVehiculos)
            {
                ItemsBooks.Add(_vehiculo);
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
                var allBoks = await conection.GetAllVehicles();


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