using System.ComponentModel.DataAnnotations;

namespace VikingLandscaping.Models
{
    public class ContactFormModel
    {
        [Required(ErrorMessage = "Vänligen fyll i namn")]
        [RegularExpression(@"^([^0-9]*)$", ErrorMessage = "Ogiltigt namn")]
        public string Name { get; set; }
        [RegularExpression(@"(\d{9})", ErrorMessage = "Måste vara ett giltigt telefonnummer")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Vänligen fyll i en e-post adress")]
        [RegularExpression(@"^.+@[^\.].*\.[a-z]{2,}$", ErrorMessage = "Ogiltigt e-post")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vänligen fyll i ärende")]
        public string Message { get; set; }
    }
}