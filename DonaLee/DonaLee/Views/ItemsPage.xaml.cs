using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using iParking.Models;
using iParking.Views;
using iParking.ViewModels;

namespace iParking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Libro;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(item));

            // Manually deselect item.
            //ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushModalAsync(new NavigationPage(new PageNuevoVehiculo()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.ItemsBooks.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        async private void BtnRegistrar(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", ""+ viewModel.ItemsBooks, "Ok");
        }
    }
}