using System;
using System.Collections.Generic;

namespace UnyimeWebApp.Models;

public partial class EntityReview
{
    public int EntityReviewId { get; set; }

    public int? EntityId { get; set; }

    public string? Review { get; set; }

    public int? Rating { get; set; }

    public virtual Entity? Entity { get; set; }
}
