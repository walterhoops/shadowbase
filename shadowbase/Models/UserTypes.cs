using System.ComponentModel.DataAnnotations;
namespace shadowbase.Models;

public class UserTypes
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Type ID is required")]
    [StringLength(10, ErrorMessage = "Type ID cannot exceed 10 characters")]
    [Display(Name = "Type ID")]
    public string TypeID { get; set; }

    [Display(Name = "Type Description")]
    [StringLength(100, ErrorMessage = "Type Description cannot exceed 100 characters")]
    [DataType(DataType.Text)]
    public string TypeDescription { get; set; }
}
