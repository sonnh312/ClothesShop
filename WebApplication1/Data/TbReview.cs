using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class TbReview
{
    public string IdReview { get; set; } = null!;

    public string? IdProduct { get; set; }

    public int IdUser { get; set; }

    public string? Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime? ReviewDate { get; set; }

    public virtual TbProduct? IdProductNavigation { get; set; }

    public virtual TbUser IdUserNavigation { get; set; } = null!;
}
