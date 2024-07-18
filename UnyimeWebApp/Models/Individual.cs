using System;
using System.Collections.Generic;

namespace UnyimeWebApp.Models;

public partial class Individual
{
    public int IndividualId { get; set; }

    public string IndividualUserName { get; set; } = null!;

    public string IndividualPasswordHash { get; set; } = null!;

    public string OtherNames { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string LocationCity { get; set; } = null!;

    public string? LocationCountry { get; set; }

    public string? LocationContinent { get; set; }

    public string PhoneNumber1 { get; set; } = null!;

    public string? PhoneNumber2 { get; set; }

    public string EmailAddress { get; set; } = null!;

    public string? LinkedinUsername { get; set; }

    public string? PersonalWebsite { get; set; }

    public virtual ICollection<IndividualApplication> IndividualApplications { get; set; } = new List<IndividualApplication>();

    public virtual ICollection<IndividualDonation> IndividualDonations { get; set; } = new List<IndividualDonation>();

    public virtual ICollection<IndividualExperience> IndividualExperiences { get; set; } = new List<IndividualExperience>();

    public virtual ICollection<IndividualFavourite> IndividualFavourites { get; set; } = new List<IndividualFavourite>();

    public virtual ICollection<IndividualReview> IndividualReviews { get; set; } = new List<IndividualReview>();

    public virtual ICollection<Sdg> Sdgs { get; set; } = new List<Sdg>();
}
