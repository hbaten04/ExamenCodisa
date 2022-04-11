using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenCodisa.Models
{
    public class Area
    {
        public int idArea { get; set; }

        [Required(ErrorMessage = "El nombre del area es requerido")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "La descripción del area es requerida")]
        public string descripcion { get; set; }
    }
}
