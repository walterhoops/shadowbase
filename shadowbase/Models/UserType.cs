using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace shadowbase.Models;

public class UserType
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Key]
    public int UserTypeID { get; set; }

    [Required]
    public string UserTypeDescription { get; set; }

    public ICollection<User> Users { get; set; }
}