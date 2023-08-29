using Microsoft.EntityFrameworkCore;

namespace Intotech.Common.Bll.Interfaces;

public class ModelBase : DbContextOptionsBuilder<DbContext>
{
    public int Id { get; set; }
}