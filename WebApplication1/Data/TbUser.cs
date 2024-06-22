using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class TbUser
{
    public int IdUser { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? IdOrder { get; set; }

    public string? IdReview { get; set; }

    public string? IdWishlist { get; set; }

    public virtual ICollection<TbOrder> TbOrders { get; set; } = new List<TbOrder>();

    public virtual ICollection<TbReview> TbReviews { get; set; } = new List<TbReview>();
}
