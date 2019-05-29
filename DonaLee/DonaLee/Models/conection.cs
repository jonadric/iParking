using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using iParking.Models;


namespace iParking.Models
{
    public class conection
    {
        FirebaseClient firebase = new FirebaseClient("https://iparkeadero.firebaseio.com/");
        public async Task<List<Usuario>> GetAllUsers()
        {

            return (await firebase
              .Child("Users")
              .OnceAsync<Usuario>()).Select(item => new Usuario
              {
                  NombresUsuario = item.Object.NombresUsuario,
                  ApellidosUsuario = item.Object.ApellidosUsuario,
                  ContraseniaUsuario = item.Object.ContraseniaUsuario,
                  CorreoUsuario = item.Object.CorreoUsuario,
                  IdUsuario = item.Object.IdUsuario
              }).ToList();
        }

        public async Task AddUser(string CorreoUsuario, string NombresUsuario, string ApellidosUsuario , string Contrasenia,int idUsuario)
            {

                await firebase
                  .Child("Users")
                  .PostAsync(new Usuario() { CorreoUsuario = CorreoUsuario, NombresUsuario = NombresUsuario, ApellidosUsuario  = ApellidosUsuario ,ContraseniaUsuario= Contrasenia,IdUsuario=idUsuario });
            }

            public async Task<Usuario> GetUser(string correo)
            {
                var allUsers = await GetAllUsers();
                await firebase
                  .Child("Users")
                  .OnceAsync<Usuario>();
                return allUsers.Where(a => a.CorreoUsuario == correo).FirstOrDefault();
            }

        public async Task<Usuario> GetUserById(int id)
        {
            var allUsers = await GetAllUsers();
            await firebase
              .Child("Users")
              .OnceAsync<Usuario>();
            return allUsers.Where(a => a.IdUsuario == id).FirstOrDefault();
        }

        public async Task UpdateUser(int IdUsuario, string NombresUsuario)
            {
                var toUpdatePerson = (await firebase
                  .Child("Users")
                  .OnceAsync<Usuario>()).Where(a => a.Object.IdUsuario == IdUsuario).FirstOrDefault();

                await firebase
                  .Child("Users")
                  .Child(toUpdatePerson.Key)
                  .PutAsync(new Usuario() { IdUsuario = IdUsuario, NombresUsuario = NombresUsuario });
            }
            

            public async Task DeleteUser(int IdUsuario)
            {
                var toDeletePerson = (await firebase
                  .Child("Users")
                  .OnceAsync<Usuario>()).Where(a => a.Object.IdUsuario == IdUsuario).FirstOrDefault();
                await firebase.Child("Users").Child(toDeletePerson.Key).DeleteAsync();

            }

        public async Task<List<Vehiculo>> GetAllVehicles()
        {

            return (await firebase
              .Child("Vehicles")
              .OnceAsync<Vehiculo>()).Select(item => new Vehiculo
              {
                  color = item.Object.color,
                  IdUser = item.Object.IdUser,
                  marca = item.Object.marca,
                  modelo = item.Object.modelo,
                  placa = item.Object.placa,
                  tipoVehiculo = item.Object.tipoVehiculo
              }).ToList();
        }
        public async Task AddVehicles(Vehiculo newVehiculo,int idUser)
        {

            await firebase
              .Child("Vehicles")
              .PostAsync(new Vehiculo {color= newVehiculo.color,marca= newVehiculo.marca,modelo= newVehiculo.modelo,placa= newVehiculo.placa,IdUser= newVehiculo.IdUser });
        }
        public async Task UpdateBookByID(Libro Libre,int IdNewUser)
        {
            var toUpdateBook = (await firebase
                  .Child("Books")
                  .OnceAsync<Libro>()).Where(a => a.Object.IdBook == Libre.IdBook).FirstOrDefault();

            await firebase
              .Child("Books")
              .Child(toUpdateBook.Key)
              .PutAsync(new Libro() { Anio__c = Libre.Anio__c, Autor__c = Libre.Autor__c, Descripcion__c = Libre.Descripcion__c, Editorial__c = Libre.Editorial__c, Genero = Libre.Genero, Imagen__c = Libre.Imagen__c, ISBN__c = Libre.ISBN__c, Titulo__c = Libre.Titulo__c, idUser = IdNewUser.ToString(), IdBook = Libre.IdBook, Paginas = Libre.Paginas, Ubicacion = Libre.Ubicacion });
           
        }


    }
}
