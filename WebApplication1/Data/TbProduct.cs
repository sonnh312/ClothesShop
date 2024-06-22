using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class TbProduct
{
    public string IdProduct { get; set; } = null!;

    public string? IdCategory { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public double? Price { get; set; }

    public byte[]? Image { get; set; }

    public int? StockQuantity { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Type { get; set; }

    public string? Size { get; set; }

    public virtual TbCategory? IdCategoryNavigation { get; set; }

    public virtual ICollection<TbReview> TbReviews { get; set; } = new List<TbReview>();
}
