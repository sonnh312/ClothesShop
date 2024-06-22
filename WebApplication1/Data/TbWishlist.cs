using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class TbWishlist
{
    public string? IdWishlist { get; set; }

    public int IdUser { get; set; }

    public string? IdProduct { get; set; }

    public virtual TbProduct? IdProductNavigation { get; set; }

    public virtual TbUser IdUserNavigation { get; set; } = null!;
}
