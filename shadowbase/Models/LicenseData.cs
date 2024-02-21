using System.ComponentModel.DataAnnotations;
namespace shadowbase.Models;

public class LicenseData
{
    public int Id { get; set; }
    [Required]
    public int UserID { get; set; }
    public string? reLicense { get; set; }
    public string? mbLicense { get; set; }
    public string? hiLicense { get; set; }

    public ICollection<UserData> UserData { get; set; }
}
