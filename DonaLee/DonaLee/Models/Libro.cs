using System;
using System.Collections.Generic;
using System.Text;

namespace iParking.Models
{
    public class Libro
    {
        public String Anio__c { get; set; }
        public String Autor__c { get; set; }
        public String Editorial__c { get; set; }
        public int IdBook { get; set; }
        public String Imagen__c { get; set; }
        public String ISBN__c { get; set; }
        public String Titulo__c { get; set; }
        public String Genero{ get; set; }
        public String Descripcion__c { get; set; }
        public int Valoracion__c { get; set; }
        public String idUser { get; set; } 
        public String Estado { get; set; }
        public String Reseña { get; set; }
        public int likes { get; set; }
        public int dislikes { get; set; }
        public int Paginas { get; set; }
        public Ubicacion Ubicacion { get; set; }
        
        public Libro()
        {

        }

        public override String ToString()
        {
            return "LIBRO [" + "Id :" + IdBook + " " + "ISBN__c :" + ISBN__c + " " + "Titulo__c :" + Titulo__c + " " 
                + "Editorial__c :" + Editorial__c + " " + "Autor__c :" + Autor__c + " " + "Anio__c :" 
                + Anio__c + " " + "Imagen__c :" + Imagen__c + " " + "Genero__c :" + Genero + " " 
                + "Descripcion__c :" + Descripcion__c + "]";
        }

        
    }
   
}