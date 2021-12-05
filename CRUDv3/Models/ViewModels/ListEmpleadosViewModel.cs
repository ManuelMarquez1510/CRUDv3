using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDv3.Models.ViewModels
{
    public class ListEmpleadosViewModel
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime Fecha_Nacimiento  { get; set; }
        public double Sueldo { get; set; }
        public string Departamento { get; set; }
        
    }
}