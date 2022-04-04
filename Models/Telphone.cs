using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using CrudClients.Validation;

namespace CrudClients.Models
{
    [Index(nameof(Number), IsUnique = true)]
    public class Telphone
    {
        public int ID { get; set; }
        [Required]
        [RegularExpression(@"\d{10,}", ErrorMessage = "Add a valid number.")]
        public string Number { get; set; }
        [Required]
        [TypeOfTelphone]
        public string Type { get; set; }
        public int ClientID { get; set; }
    }
}