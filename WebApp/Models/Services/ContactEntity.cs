using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WebApp.Models.Services;

public class ContactEntity
{
    
    public int Id { get; set; }
    [Required]
    [MaxLength(length: 20, ErrorMessage = "More then 20 characters is not allowed")]
    [MinLength(length: 2, ErrorMessage = "Less then 20 characters is not allowed")]
    [Display(Name = "Imię")]

    public string FirstName { get; set; }
    [Required]
    [MaxLength(length: 50, ErrorMessage = "More then 50 characters is not allowed")]
    [MinLength(length: 2, ErrorMessage = "Less then 20 characters is not allowed")]
    [Display(Name = "Nazwisko")]

    public string LastName { get; set; }
    [EmailAddress]
    [Display(Name = "Adres e-mail")]

    public string Email { get; set; }
    [Phone]
    [RegularExpression(pattern: "\\d{3} \\d{3} \\d{3}", ErrorMessage = "Enter number like this: xxx xxx xxx")]
    [Display(Name = "Numer telefonu")]

    public string PhoneNumber { get; set; }
    [DataType(DataType.Date)]
    
    [Display(Name = "Data urodzenia")]
    
    // [Column("birth")]
    public DateOnly BirthDate { get; set; }

    [Display(Name = "Kategoria")]

    public Category Category { get; set; }
    public DateTime Created { get; set; }
    
    public int OrganizationId { get; set; }
    
    public OrganizationEntity? Organization { get; set; }
}