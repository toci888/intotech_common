using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Intotech.Common.Bll.Interfaces;

[Serializable]
public class ModelBase
{
    [Key]
    [Column("Id")]
    public int Id { get; set; }
}