using System;
using System.Collections.Generic;

namespace UnyimeWebApp.Models;

public partial class Entity
{
    public int EntityId { get; set; }

    public string EntityUserName { get; set; } = null!;

    public string EntityPasswordHash { get; set; } = null!;

    public string EntityName { get; set; } = null!;

    public string? EntityType { get; set; }

    public string LocationCity { get; set; } = null!;

    public string? LocationCountry { get; set; }

    public string? LocationContinent { get; set; }

    public string? About { get; set; }

    public string PhoneNumber1 { get; set; } = null!;

    public string? PhoneNumber2 { get; set; }

    public string EmailAddress { get; set; } = null!;

    public string? Website { get; set; }

    public virtual ICollection<EntityReview> EntityReviews { get; set; } = new List<EntityReview>();

    public virtual ICollection<Sdg> Sdgs { get; set; } = new List<Sdg>();
}
