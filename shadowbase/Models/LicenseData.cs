using System.ComponentModel.DataAnnotations;
namespace shadowbase.Models;

public class LicenseData
{
    public int Id { get; set; }
    [Required(ErrorMessage = "User ID is required")]
    public int UserID { get; set; }
    [Display(Name = "Real Estate License")]
    [RegularExpression(@"^[A-Za-z0-9]{6,}$", ErrorMessage = "License must be alphanumeric and at least 6 characters long")]
    public string? reLicense { get; set; }
    [Display(Name = "Mortgage Broker License")]
    [RegularExpression(@"^[A-Za-z0-9]{6,}$", ErrorMessage = "License must be alphanumeric and at least 6 characters long")]
    public string? mbLicense { get; set; }
    [Display(Name = "Home Insurance License")]
    [RegularExpression(@"^[A-Za-z0-9]{6,}$", ErrorMessage = "License must be alphanumeric and at least 6 characters long")]
    public string? hiLicense { get; set; }
  
    public ICollection<UserData> UserData { get; set; }
}