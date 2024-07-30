using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemasInventarioV7.Modelos
{
    public class Bodega
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Nombre de la Bodega es requerido")]
        [MaxLength(100, ErrorMessage ="Nombre maximo 100 caracteres")]
        public String Nombre { get; set; }

        [Required(ErrorMessage = "Nombre de la Descripcion es requerido")]
        [MaxLength(100, ErrorMessage = "Descripcion maximo 100 caracteres")]
        public String Descripcion { get; set; } 

        [Required(ErrorMessage = "Estado es requerido")]
        public bool Estado { get; set; }
    }
}
