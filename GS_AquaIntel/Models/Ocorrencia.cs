using GS_AquaIntel.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GS_AquaIntel.Models;

[Table("OCORRENCIAS")]
public class Ocorrencia
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Required]
    [Column("DESCRICAO", TypeName = "VARCHAR2(500)")]
    public string Descricao { get; set; }

    [Required]
    [Column("DATA", TypeName = "DATE")]
    public DateTime Data { get; set; }

    [ForeignKey("Usuario")]
    [Column("USUARIO_ID")]
    public int UsuarioId { get; set; }

    public Usuario Usuario { get; set; }
}

