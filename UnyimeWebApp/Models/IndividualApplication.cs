using System;
using System.Collections.Generic;

namespace UnyimeWebApp.Models;

public partial class IndividualApplication
{
    public int IndividualApplicationId { get; set; }

    public int? IndividualId { get; set; }

    public int? InitiativeId { get; set; }

    public int? InitiativeNeedId { get; set; }

    public string? ApplicationStatus { get; set; }

    public DateTime? DateApplied { get; set; }

    public DateTime? DateUnderReview { get; set; }

    public DateTime? DateRejected { get; set; }

    public string? Field { get; set; }

    public virtual Individual? Individual { get; set; }

    public virtual ICollection<IndividualExperience> IndividualExperiences { get; set; } = new List<IndividualExperience>();

    public virtual Initiative? Initiative { get; set; }

    public virtual InitiativeNeed? InitiativeNeed { get; set; }
}
