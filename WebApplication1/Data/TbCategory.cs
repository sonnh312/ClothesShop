using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class TbCategory
{
    public string IdCategory { get; set; } = null!;

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? IdProduct { get; set; }

    public virtual ICollection<TbProduct> TbProducts { get; set; } = new List<TbProduct>();
}
