using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Models
{
    public class Machine
    {
        [Required]
        [Display(Name = "MID")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "La longitud del campo deber ser entre {2} y {1}")]
        public string Id { get; set; }

        [Required]
        [Display(Name = "FID")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "La longitud del campo deber ser entre {2} y {1}")]
        public string FID { get; set; }

        [Required]
        [Display(Name = "EOID")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "La longitud del campo deber ser entre {2} y {1}")]
        public string EOID { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "La longitud del campo deber ser entre {2} y {1}")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [Display(Name = "Producer")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "La longitud del campo deber ser entre {2} y {1}")]
        public string Producer { get; set; }

        [Required]
        [Display(Name = "Serial")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "La longitud del campo deber ser entre {2} y {1}")]
        public string Serial { get; set; }

        [Required]
        [Display(Name = "ActiveFrom")]
        public DateTime ActiveFrom { get; set; }
    }
}
