using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using iParking.ViewModels;
using iParking.Models;

namespace iParking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MisLibrosDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;
        public Libro item1;
        public MisLibrosDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }
        public MisLibrosDetailPage(Libro item)
        {
            InitializeComponent();

            item1 = item;
            viewModel = new ItemDetailViewModel(item1);
            BindingContext = viewModel;

        }
        async private void BntEntregar(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new EntregaPage(item1));

        }
    }
}