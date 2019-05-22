using System;
using System.Collections.Generic;
using System.Text;

namespace iParking.Models
{
    public class Publicacion
    {
        public String Id { get; set; }
        public String Tipo__c { get; set; }
        public String Estado__c { get; set; }
        public String ColorEstado { get; set; }
        public String Libro__c { get; set; }
        public String Usuario__c { get; set; }
        public Libro Libro__r { get; set; }
        public String Usuario__r { get; set; }
        public String NombreLibro { get; set; }
        public String NombreAutor { get; set; }
        public String NombreUsuario { get; set; }
        public String Imagen { get; set; }
        public String Valoracion { get; set; }
        public String Genero { get; set; }
        public String ISBN { get; set; }
        public String Donatario__r { get; set; }
        public String IdUsuario { get; set; }
        public String MensajeDonante { get; set; }
        public String Lugar { get; set; }
        public String Fecha { get; set; }
        public String Hora { get; set; }

        public Publicacion()
        {

        }

        public Publicacion(String tipo, String estado, String idLibro, String idUsuario)
        {
            this.Tipo__c = tipo;
            this.Estado__c = estado;
            this.Libro__c = idLibro;
            this.Usuario__c = idUsuario;
        }

        public override string ToString()
        {
            return "PUBLICACION [" + "Id:" + Id + "Tipo__c:" + Tipo__c + "Estado__c:" + Estado__c + "Libro__c:" 
                + Libro__c + "Usuario__c:" + Usuario__c + "Libro__r:" + Libro__r + "Usuario__r:" + Usuario__r
                + "NombreLibro:" + NombreLibro + "NombreAutor:" + NombreAutor + "NombreUsuario:" + NombreUsuario 
                + "Imagen:" + Imagen + "Valoracion:" + Valoracion + "Genero:" + Genero + "ISBN:" + ISBN 
                + "IdUsuario:" + IdUsuario + ", Donatario__r.Nombres__c:" + Donatario__r/*.Nombres__c*/ + "]";
        }
    }
}
