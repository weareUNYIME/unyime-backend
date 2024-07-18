using System;
using System.Collections.Generic;

namespace UnyimeWebApp.Models;

public partial class IndividualFavourite
{
    public int IndividualFavouriteId { get; set; }

    public int? IndividualId { get; set; }

    public int? InitiativeId { get; set; }

    public virtual Individual? Individual { get; set; }

    public virtual Initiative? Initiative { get; set; }
}
