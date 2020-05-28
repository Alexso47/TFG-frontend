using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace PlataformaWEB.Models
{
    public class Country
    {
        public Country(string Name) 
        {
            this.Name = Name;
        }

        //public short Id { get; set; }

        //[Required]
        //public string Code { get; set; }

        public string Name { get; set; }

        //public bool IsEU { get; set; }

        //public bool Enabled { get; set; }
    }
}
