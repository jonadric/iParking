using System;
using System.Collections.Generic;
using System.Text;

namespace iParking.Models
{
    public class Vehiculo
    {
        public string placa { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string color { get; set; }
        public string tipoVehiculo { get; set; }
        //public string hora_entrada { get; set; }
        public int IdUser { get; set; }


    }
}
