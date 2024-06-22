using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class TbOrder
{
    public string IdOrder { get; set; } = null!;

    public int IdUser { get; set; }

    public DateOnly? OrderDate { get; set; }

    public double? TotalAmount { get; set; }

    public string? IdOrderItems { get; set; }

    public virtual TbUser IdUserNavigation { get; set; } = null!;
}
