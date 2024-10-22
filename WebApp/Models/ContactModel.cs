using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Models
{
    public class ContactModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Imię nie może być większe niż 20 znaków")]
        [MinLength(2, ErrorMessage = "Imię musi mieć co najmniej 2 znaki!")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Imię nie może być większe niż 50 znaków")]
        [MinLength(2, ErrorMessage = "Imię musi mieć co najmniej 2 znaki!")]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [RegularExpression(@"\d{3} \d{3} \d{3}", ErrorMessage = "Wpisz numer wg wzoru: xxx xxx xxx")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        public DateOnly BirthDate { get; set; }
    }
}