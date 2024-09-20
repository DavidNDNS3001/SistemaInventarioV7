using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemasInventarioV7.Modelos
{
    public class Marca
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre de marca es requerido")]
        [MaxLength(100, ErrorMessage = "Nombre de marca debe ser maximo 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Descripcion de marca es requerido")]
        [MaxLength(100, ErrorMessage = "Descripcion de marca debe ser maximo 100 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Estado de marca es requerido")]
        public bool Estado { get; set; }


    }
}
