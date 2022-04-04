using System.ComponentModel.DataAnnotations;

namespace CrudClients.Models
{
    public class Address
    {
        public int ID { get; set; }
        [Required]
        public string CEP { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Neighborhood { get; set; }
        [Required]
        public string Complement { get; set; }
        [Required]
        public int ClientID { get; set; }
    }
}