using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemasInventarioV7.Modelos
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Nombre de categoria es requerido")]
        [MaxLength(100, ErrorMessage ="Nombre de categoria debe ser maximo 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Descripcion de categoria es requerido")]
        [MaxLength(100, ErrorMessage = "Descripcion de categoria debe ser maximo 100 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Estado de categoria es requerido")]
        public bool Estado { get; set; }

    }
}
