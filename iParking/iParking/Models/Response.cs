using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace iParking.Models
{
    class Response
    {
        public String Usuario { get; set; }
        public Boolean Resultado { get; set; }        
        public String Mensaje { get; set; }
        public Libro Libro { get; set; }
        public List<Publicacion> LstPublicaciones { get; set; }

        public static implicit operator Response(HttpResponseMessage v)
        {
            throw new NotImplementedException();
        }
    }
}
