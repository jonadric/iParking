using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using iParking.Models;
using iParking.ViewModels;

namespace iParking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;
        public Libro item1;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage(Libro item)
        {
            InitializeComponent();

            item1 = item;
            viewModel = new ItemDetailViewModel(item1);
            BindingContext = viewModel;

        }

       async private void BntPedir(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SolicitudPage(item1));

        }
    }
}