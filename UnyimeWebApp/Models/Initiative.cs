using System;
using System.Collections.Generic;

namespace UnyimeWebApp.Models;

public partial class Initiative
{
    public int InitiativeId { get; set; }

    public int? SdgId { get; set; }

    public string InitiativeName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string LocationCity { get; set; } = null!;

    public string? LocationCountry { get; set; }

    public string? LocationContinent { get; set; }

    public int Duration { get; set; }

    public DateTime CommencementDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string Sdgs { get; set; } = null!;

    public string? InitiativeDescription { get; set; }

    public string? Eligibility { get; set; }

    public virtual ICollection<IndividualApplication> IndividualApplications { get; set; } = new List<IndividualApplication>();

    public virtual ICollection<IndividualDonation> IndividualDonations { get; set; } = new List<IndividualDonation>();

    public virtual ICollection<IndividualFavourite> IndividualFavourites { get; set; } = new List<IndividualFavourite>();

    public virtual ICollection<InitiativeMedium> InitiativeMedia { get; set; } = new List<InitiativeMedium>();

    public virtual ICollection<InitiativeNeed> InitiativeNeeds { get; set; } = new List<InitiativeNeed>();

    public virtual Sdg? Sdg { get; set; }

    public virtual ICollection<Sdg> SdgsNavigation { get; set; } = new List<Sdg>();
}
