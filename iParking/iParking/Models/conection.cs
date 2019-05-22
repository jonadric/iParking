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
        FirebaseClient firebase = new FirebaseClient("https://donalee-37b9f.firebaseio.com/");
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

        public async Task<List<Libro>> GetAllBooks()
        {

            return (await firebase
              .Child("Books")
              .OnceAsync<Libro>()).Select(item => new Libro
              {
                  Anio__c = item.Object.Anio__c,
                  Autor__c = item.Object.Autor__c,
                  Editorial__c = item.Object.Editorial__c,
                  IdBook = item.Object.IdBook,
                  Imagen__c = item.Object.Imagen__c,
                  ISBN__c = item.Object.ISBN__c,
                  Titulo__c = item.Object.Titulo__c,
                  Genero = item.Object.Genero,
                  Descripcion__c = item.Object.Descripcion__c,
                  Valoracion__c = item.Object.Valoracion__c,
                  idUser = item.Object.idUser,
                  Paginas = item.Object.Paginas,
                  Ubicacion = item.Object.Ubicacion
              }).ToList();
        }
        public async Task AddBook(Libro booksito,int idUser)
        {

            await firebase
              .Child("Books")
              .PostAsync(new Libro() { Anio__c = booksito.Anio__c, Autor__c = booksito.Autor__c, Descripcion__c = booksito.Descripcion__c, Editorial__c = booksito.Editorial__c, Genero = booksito.Genero, Imagen__c = booksito.Imagen__c, ISBN__c = booksito.ISBN__c, Titulo__c =booksito.Titulo__c,idUser= idUser.ToString(),IdBook=booksito.IdBook,Paginas=booksito.Paginas,Ubicacion=booksito.Ubicacion});
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
