using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Models
{
    public class Product
    {
        [Required]
        [Display(Name = "Código")]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "La longitud del campo deber ser entre {2} y {1}")]
        public string Code { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "La longitud del campo deber ser entre {2} y {1}")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [Display(Name = "Tipo")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "La longitud del campo deber ser entre {2} y {1}")]
        public string Type { get; set; }
    }
}
