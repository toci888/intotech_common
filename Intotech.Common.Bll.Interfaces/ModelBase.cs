using Microsoft.EntityFrameworkCore;

namespace Intotech.Common.Bll.Interfaces;

[Serializable]
public class ModelBase //: DbContextOptionsBuilder<DbContext>
{
    public int Id { get; set; }
}