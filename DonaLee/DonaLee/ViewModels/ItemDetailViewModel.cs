using System;

using iParking.Models;

namespace iParking.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Libro Item { get; set; }
        public ItemDetailViewModel(Libro item)
        {
            Title = item?.Titulo__c;
            Item = item;
        }
    }
}
