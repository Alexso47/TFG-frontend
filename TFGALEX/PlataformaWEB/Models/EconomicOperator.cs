using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace PlataformaWEB.Models
{
    public class EconomicOperator
    {
        public EconomicOperator() { }

        [Required]
        [Display(Name = "EOID")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "La longitud del campo deber ser entre {2} y {1}")]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "La longitud del campo deber ser entre {2} y {1}")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "La longitud del campo deber ser entre {2} y {1}")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Código Postal")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "La longitud del campo deber ser entre {2} y {1}")]
        public string ZipCode { get; set; }

        [Required]
        [Display(Name = "Ciudad")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "La longitud del campo deber ser entre {2} y {1}")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "ActiveFrom")]
        public DateTimeOffset ActiveFrom { get; set; }
    }
}
