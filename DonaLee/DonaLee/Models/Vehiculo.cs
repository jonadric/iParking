using System;
using System.Collections.Generic;
using System.Text;

namespace iParking.Models
{
    public class Vehiculo
    {
        public string placa;
        public string marca;
        public string modelo;
        public string color;
        public string tipoVehiculo;
        public string hora_entrada;

        public Vehiculo(string placa1, string marca1, string modelo1, string color1, string tipoVehiculo1, string hora_entrada1)
        {
            this.placa = placa1;
            this.marca = marca1;
            this.modelo = modelo1;
            this.color = color1;
            this.tipoVehiculo = tipoVehiculo1;
            this.hora_entrada = hora_entrada1;

        }

        public string Placa
        {
            get { return placa; }
            set { this.placa = value; }
        }
        public string Marca
        {
            get { return marca; }
            set { this.marca = value; }
        }
        public string Modelo
        {
            get { return modelo; }
            set { this.modelo = value; }
        }
        public string Color
        {
            get { return color; }
            set { this.color = value; }
        }

        public string TipoVehiculo
        {
            get { return tipoVehiculo; }
            set { this.tipoVehiculo = value; }
        }
        public string Hora_entrada
        {
            get { return hora_entrada; }
            set { this.hora_entrada = value; }
        }
    }
}
