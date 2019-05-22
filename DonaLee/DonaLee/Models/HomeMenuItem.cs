using System;
using System.Collections.Generic;
using System.Text;

namespace iParking.Models
{
    public enum MenuItemType
    {
        Perfil,
        Browse,
        MisLibros,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
