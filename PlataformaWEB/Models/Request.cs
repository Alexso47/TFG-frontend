using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Models
{
    public class Request
    {
        [Required]
        [Display(Name = "Id")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "La longitud del campo deber ser entre {2} y {1}")]
        public string Id { get; set; }

        [Required]
        [Display(Name = "FID")]
        public string FID { get; set; }

        [Required]
        [Display(Name = "EOID")]
        public string EOID { get; set; }

        [Required]
        [Display(Name = "MID")]
        public string MID { get; set; }

        [Required]
        [Display(Name = "ProductName")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Tipo")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "La longitud del campo deber ser entre {2} y {1}")]
        public string Type { get; set; }

        public string Description { get; set; }

        [Required]
        [Display(Name = "Mercado")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "La longitud del campo deber ser entre {2} y {1}")]
        public string Market { get; set; }

        [Required]
        [Display(Name = "Ruta")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "La longitud del campo deber ser entre {2} y {1}")]
        public string Route { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Manufacturing Line")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "La longitud del campo deber ser entre {2} y {1}")]
        public string MLine { get; set; }

        [StringLength(200, MinimumLength = 0, ErrorMessage = "La longitud del campo deber ser entre {2} y {1}")]
        public string Comments { get; set; }

    }
}
