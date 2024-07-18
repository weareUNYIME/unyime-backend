using System;
using System.Collections.Generic;

namespace UnyimeWebApp.Models;

public partial class InitiativeNeed
{
    public int InitiativeNeedId { get; set; }

    public int? InitiativeId { get; set; }

    public string NeedType { get; set; } = null!;

    public string? NeedDetails { get; set; }

    public virtual ICollection<IndividualApplication> IndividualApplications { get; set; } = new List<IndividualApplication>();

    public virtual Initiative? Initiative { get; set; }
}
