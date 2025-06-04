
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GS_AquaIntel.Models;

[Table("USUARIOS")]
public class Usuario
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Required]
    [Column("NOME", TypeName = "VARCHAR2(100)")]
    public string Nome { get; set; }

    [Required]
    [Column("EMAIL", TypeName = "VARCHAR2(100)")]
    public string Email { get; set; }


}