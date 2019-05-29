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

        public ObservableCollection<Vehiculo> ItemsVehicles { get; set; }
        public Command LoadItemsCommand { get; set; }

        public MisLibrosModel()
        {
            Title = "MisCarros";
            ItemsVehicles = new ObservableCollection<Vehiculo>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

        }

        async Task llenarDeComienzo()
        {
            var allVehicles = await conection.GetAllVehicles();
            foreach (var vehicle in allVehicles)
            {
                var valor = Application.Current.Properties["id_User"];
                if (vehicle.IdUser == int.Parse( valor.ToString()))
                {
                    ItemsVehicles.Add(vehicle);

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
                ItemsVehicles.Clear();
                await llenarDeComienzo();
                //var allBoks = await conection.GetAllVehicles();
                ////var items = await DataStore.GetItemsAsync(true);
                //foreach (var libro in allBoks)
                //{
                //    ItemsVehicles.Add(libro);
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
