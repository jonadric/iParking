using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iParking.Models;

namespace iParking.Services
{
    public class MockDataStore : IDataStore<Libro>
    {
        List<Libro> itemsBooks;

        public MockDataStore()
        {
            itemsBooks = new List<Libro>();
            var mockItems = new List<Libro>
            {
                new Libro {Anio__c="1996",Autor__c="Davidapps",Descripcion__c="Este es el mejor libro",Editorial__c="VisualSolution",IdBook=000,Imagen__c="https://upload.wikimedia.org/wikipedia/commons/thumb/4/4f/Csharp_Logo.png/245px-Csharp_Logo.png",ISBN__c="00000001",Titulo__c="EL AMO DE TODO",Valoracion__c=5}
            };

            foreach (var item in mockItems)
            {
                itemsBooks.Add(item);
            }
        }

        public Task<bool> AddItemAsync(Libro item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        //public async Task<bool> AddItemAsync(Libro itemBook)
        //{
        //    items.Add(item);

        //    return await Task.FromResult(true);
        //}

        //public async Task<bool> UpdateItemAsync(Item item)
        //{
        //    var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
        //    items.Remove(oldItem);
        //    items.Add(item);

        //    return await Task.FromResult(true);
        //}

        //public async Task<bool> DeleteItemAsync(string id)
        //{
        //    var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
        //    items.Remove(oldItem);

        //    return await Task.FromResult(true);
        //}

        //public async Task<Item> GetItemAsync(string id)
        //{
        //    return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        //}

        //public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        //{
        //    return await Task.FromResult(items);
        //}

        public Task<bool> UpdateItemAsync(Libro item)
        {
            throw new NotImplementedException();
        }

        Task IDataStore<Libro>.AddItemAsync(Libro newItem)
        {
            throw new NotImplementedException();
        }

        Task<Libro> IDataStore<Libro>.GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Libro>> IDataStore<Libro>.GetItemsAsync(bool forceRefresh)
        {
            throw new NotImplementedException();
        }
    }
}