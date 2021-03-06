﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using iParking.Models;
using iParking.ViewModels;

namespace iParking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MisVehiculosPage : ContentPage
    {
        MisLibrosModel viewModel;
        public MisVehiculosPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new MisLibrosModel();
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            //var item = args.SelectedItem as Vehiculo;
            //if (item == null)
            //    return;

            //await Navigation.PushAsync(new MisVehiculosDetailPage(item));

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

            if (viewModel.ItemsVehicles.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        async private void BtnRegistrar(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "" + viewModel.ItemsVehicles, "Ok");
        }
    }
}