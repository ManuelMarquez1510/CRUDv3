using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDv3.Models.ViewModels
{
    public class EmpleadosViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombres")]
        [RegularExpression("^[a-zA-Z]+$",ErrorMessage ="Solo se aceptan letras en el campo Nombres")]
        public string Nombres { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Solo se aceptan letras en el campo Apellidos")]
        public string Apellidos { get; set; }

        [Required]
        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        public DateTime Fecha_Nacimiento { get; set; }

        [Required]
        [Display(Name = "Sueldo")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Solo se aceptan numero en el campo Sueldo")]
        public double Sueldo { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Departamento")]
        public string Departamento { get; set; }

    }
}