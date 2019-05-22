using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace iParking.ViewModels
{
    class EntregaModel : BaseViewModel
    {

        public EntregaModel ()
        {
            Title = "Entregas iParking";

        }
        public ICommand EntregaCommand { get; }


    }
}
