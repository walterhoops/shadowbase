using System.ComponentModel.DataAnnotations;
namespace shadowbase.Models;

public class UserTypes
{
    public int Id { get; set; }
    public string? TypeID { get; set; }
    [DataType(DataType.Text)]
    public string? TypeDescription { get; set; }
}
