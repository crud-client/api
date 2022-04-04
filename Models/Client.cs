using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CrudClients.Models
{
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(RG), IsUnique = true)]
    [Index(nameof(CPF), IsUnique = true)]
    [Index(nameof(Facebook), IsUnique = true)]
    [Index(nameof(Linkedin), IsUnique = true)]
    [Index(nameof(Twitter), IsUnique = true)]
    [Index(nameof(Instagram), IsUnique = true)]
    public class Client
    {
        public int ID { get; set; }

        [Required]        
        public string Name { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public string RG { get; set; }
        [Required]
        public string CPF { get; set; }
        
        public string Facebook { get; set; }
        public string Linkedin { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }

        public ICollection<Telphone> Telphones { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}
